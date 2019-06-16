using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.DataTransfer.CategoryDtos;
using ProdajaSladoleda.Application.Searches;
using ProdajaSladoleda.DataAccess.EFDataAccess;

namespace WEB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ProdajaSladoledaContext _context;
        private readonly IGetCategoriesCommand _getCategories;
        private readonly IGetCategoryCommand _getCategory;
        private readonly ICreateCategoryCommand _createCategory;
        private readonly IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;

        public CategoriesController(ProdajaSladoledaContext context, IGetCategoriesCommand getCategories, IGetCategoryCommand getCategory, ICreateCategoryCommand createCategory, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory)
        {
            _context = context;
            _getCategories = getCategories;
            _getCategory = getCategory;
            _createCategory = createCategory;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
        }


        // GET: Categories
        public ActionResult Index([FromQuery] CategorySearch search)
        {
            var categories = _getCategories.Execute(search);
            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            var category = _getCategory.Execute(id);
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateCategoryDto dto)
        {
            try
            {
                _createCategory.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _getCategory.Execute(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryDto dto)
        {
            try
            {
                _editCategory.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            
            var category = _getCategory.Execute(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryDto dto)
        {
            try
            {
                _deleteCategory.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}