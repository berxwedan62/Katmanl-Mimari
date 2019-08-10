using Mimari.Ado.Concrete;
using Mimari.Business.Abstract;
using Mimari.Business.Concrete;
using Mimari.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mimari.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MimariContext mimari = new MimariContext();
            mimari.ExecNonQueryProc("Select * From Product");


            IProductService productManager = new ProductManager(new ProductDal());
            var x = productManager.GetAllList();
            return View(x);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            IProductService productService = new ProductManager(new ProductDal());
            productService.Add(product);
            return View();
        }

        public ActionResult Update(int? id)
        {
            IProductService productService = new ProductManager(new ProductDal());
            
            return View(productService.GetId(Convert.ToInt32(id)));
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            IProductService productService = new ProductManager(new ProductDal());
            productService.Update(product);
            return View();
        }
    }
}