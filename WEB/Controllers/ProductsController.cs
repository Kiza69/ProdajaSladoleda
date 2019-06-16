using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProdajaSladoledaContext _context;
        private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductCommand _getProduct;
        private readonly ICreateProductCommand _createProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IDeleteProductCommand _deleteProduct;
        private readonly IGetCategoryDLLCommand _getDDL;
        private readonly IEmailSending _sendEmail;

        public ProductsController(ProdajaSladoledaContext context, IGetProductsCommand getProducts, IGetProductCommand getProduct, ICreateProductCommand createProduct, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct, IGetCategoryDLLCommand getDDL, IEmailSending sendEmail)
        {
            _context = context;
            _getProducts = getProducts;
            _getProduct = getProduct;
            _createProduct = createProduct;
            _editProduct = editProduct;
            _deleteProduct = deleteProduct;
            _getDDL = getDDL;
            _sendEmail = sendEmail;
        }

        // GET: Products
        public ActionResult Index([FromQuery] ProductSearch search, DDL d)
        {
            ViewBag.Categories = _getDDL.Execute(d);
            var products = _getProducts.Execute(search);
            return View(products);
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _getProduct.Execute(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create(DDL d)
        {
            ViewBag.Categories = _getDDL.Execute(d);
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateProductDto dto, DDL d)
        {
            _sendEmail.To = "zoran.ljepoja.43.15@ict.edu.rs";
            _sendEmail.Subject = "Novi proizvod";
            _sendEmail.Body = "Upravo je unet novi proizvod";
            try
            {
                ViewBag.Categories = _getDDL.Execute(d);
                _createProduct.Execute(dto);
                _sendEmail.Send();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _getProduct.Execute(id);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] CreateProductDto dto)
        {
            try
            {
                _editProduct.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _getProduct.Execute(id);
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CreateProductDto dto)
        {
            try
            {
                _deleteProduct.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}