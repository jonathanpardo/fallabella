using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using segurosfalabella.Models;


namespace segurosfalabella.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        private SegurosFallabellaEntities ce = new SegurosFallabellaEntities();

        public ActionResult Index()
        {
            return View(ce.Producto.ToList().OrderBy(x=>x.Nombre));
        }
        
    }
}
 

