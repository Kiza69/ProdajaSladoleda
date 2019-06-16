using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.DataTransfer.CustomerDtos;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersCommand _getCustomers;
        private readonly IGetCustomerCommand _getCustomer;
        private readonly ICreateCustomerCommand _createCustomer;
        private readonly IEditCustomerCommand _editCustomer;
        private readonly IDeleteCustomerCommand _deleteCustomer;

        public CustomersController(IGetCustomersCommand getCustomers, IGetCustomerCommand getCustomer, ICreateCustomerCommand createCustomer, IEditCustomerCommand editCustomer, IDeleteCustomerCommand deleteCustomer)
        {
            _getCustomers = getCustomers;
            _getCustomer = getCustomer;
            _createCustomer = createCustomer;
            _editCustomer = editCustomer;
            _deleteCustomer = deleteCustomer;
        }
        /// <summary>
        /// Dohvatanje svih kupaca sa ugradjenom filtracijom po zadatim kriterijumima.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get([FromQuery] CustomerSearch search)
        {
            try
            {
                var customers = _getCustomers.Execute(search);
                return Ok(customers);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjenog kupca, tacno po Id-u.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            try
            {
                var customer = _getCustomer.Execute(id);
                return Ok(customer);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos kupca. Email kupca se ne sme ponoviti.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Customers
        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerDto dto)
        {
            try
            {
                _createCustomer.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka kupca.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateCustomerDto dto)
        {
            dto.CustomerId = id;
            try
            {
                _editCustomer.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje odredjenog kupca, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCustomer.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
