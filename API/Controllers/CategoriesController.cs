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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGetCategoriesCommand _getCategories;
        private readonly IGetCategoryCommand _getCategory;
        private readonly ICreateCategoryCommand _createCategory;
        private readonly IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;

        public CategoriesController(IGetCategoriesCommand getCategories, IGetCategoryCommand getCategory, ICreateCategoryCommand createCategory, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory)
        {
            _getCategories = getCategories;
            _getCategory = getCategory;
            _createCategory = createCategory;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
        }

        /// <summary>
        /// Dohvatanje svih kategorija proizvoda sa ugradjenom filtracijom po zadatim kriterijumima.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get([FromQuery] CategorySearch search)
        {
            try
            {
                var categories = _getCategories.Execute(search);
                return Ok(categories);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjene kategorije proizvoda, tacno po Id-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get([FromRoute] int id)
        {
            try
            {
                var category = _getCategory.Execute(id);
                return Ok(category);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }
        /// <summary>
        /// Unos kategorije proizvoda. Ime kategorije se ne sme ponoviti.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Categories
        [HttpPost]
        public ActionResult Post([FromBody] CreateCategoryDto dto)
        {
            try
            {
                _createCategory.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }

        }
        /// <summary>
        /// Izmena podataka kategorije proizvoda.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CategoryDto dto)
        {
            dto.CategoryId = id;
            try
            {
                _editCategory.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }
        /// <summary>
        /// Brisanje kategorije proizvoda, po prosledjenom Id-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCategory.Execute(id);
                return StatusCode(201, "Uspesno ste izbrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }
    }
}
