using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using segurosfalabella.Models;

namespace segurosfalabella.Controllers
{
    public class carritoController : Controller
    {
        // GET: carrito
        private SegurosFallabellaEntities ce = new SegurosFallabellaEntities();
        public ActionResult AgregarCarrito(int id)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(ce.Producto.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(ce.Producto.Find(id), 1));
                else
                    compras[IndexExistente].Cantidad++;
                Session["carrito"] = compras;
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("Agregarcarrito");

        }
        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Id == id)
                    return i;
            }
            return -1;
        }
        public ActionResult FinalizarCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                Venta nuevaVenta = new Venta();
                nuevaVenta.DiaVenta = DateTime.Now;
                nuevaVenta.Subtotal = compras.Sum(x => x.Producto.Precio * x.Cantidad);
                nuevaVenta.Iva = nuevaVenta.Subtotal * 0.16;
                nuevaVenta.Total = nuevaVenta.Subtotal + nuevaVenta.Iva;

                nuevaVenta.ListaVenta = (from producto in compras
                                         select new ListaVenta
                                         {
                                             ProductoId = producto.Producto.Id,
                                             Cantidad = producto.Cantidad,
                                             Total = producto.Cantidad * producto.Producto.Precio
                                         }).ToList();
                ce.Venta.Add(nuevaVenta);
                ce.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();
            }
            return View();
        }
    }
}