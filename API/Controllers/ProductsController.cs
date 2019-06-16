using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.DataTransfer.ProductDtos;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductCommand _getProduct;
        private readonly ICreateProductCommand _createProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IDeleteProductCommand _deleteProduct;

        public ProductsController(IGetProductsCommand getProducts, IGetProductCommand getProduct, ICreateProductCommand createProduct, IEditProductCommand editProduct, IDeleteProductCommand deleteProduct)
        {
            _getProducts = getProducts;
            _getProduct = getProduct;
            _createProduct = createProduct;
            _editProduct = editProduct;
            _deleteProduct = deleteProduct;
        }
        /// <summary>
        /// Dohvatanje svih proizvoda uz filtraciju.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get([FromQuery] ProductSearch search)
        {
            try
            {
                var products = _getProducts.Execute(search);
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjenog proizvoda po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            try
            {
                var product = _getProduct.Execute(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos podataka za proizvod.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Products
        [HttpPost]
        public ActionResult Post([FromBody] CreateProductDto dto)
        {
            try
            {
                _createProduct.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka odredjenog proizvoda po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateProductDto dto)
        {
            dto.ProductId = id;
            try
            {
                _editProduct.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje podataka odredjenog proizvoda po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteProduct.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
