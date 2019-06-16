using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.DataTransfer.OrderDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IGetOrdersCommand _getOrders;
        private readonly IGetOrderCommand _getOrder;
        private readonly ICreateOrderCommand _createOrder;
        private readonly IEditOrderCommand _editOrder;
        private readonly IDeleteOrderCommand _deleteOrder;
        private readonly IGetCustomerCommand _getCustomer;
        private readonly IEmailSending _sendEmail;

        public OrdersController(IGetOrdersCommand getOrders, IGetOrderCommand getOrder, ICreateOrderCommand createOrder, IEditOrderCommand editOrder, IDeleteOrderCommand deleteOrder, IGetCustomerCommand getCustomer, IEmailSending sendEmail)
        {
            _getOrders = getOrders;
            _getOrder = getOrder;
            _createOrder = createOrder;
            _editOrder = editOrder;
            _deleteOrder = deleteOrder;
            _getCustomer = getCustomer;
            _sendEmail = sendEmail;
        }
        /// <summary>
        /// Dohvatanje svih porudzbina uz filtraciju.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> Get([FromQuery] OrderSearch search)
        {
            try
            {
                var orders = _getOrders.Execute(search);
                return Ok(orders);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjene porudzbine po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            try
            {
                var order = _getOrder.Execute(id);
                return Ok(order);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos podataka odredjene porudzbine.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Orders
        [HttpPost]
        public ActionResult Post([FromBody] CreateOrderDto dto)
        {
            var customer = _getCustomer.Execute(dto.CustomerId);
            var email = customer.Email;
            _sendEmail.To = email;
            _sendEmail.Subject = "Porudzbina";
            _sendEmail.Body = "Uspesno ste kreirali porudzbinu.";
            try
            {
                _createOrder.Execute(dto);
                _sendEmail.Send();
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka odredjene porudzbine po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateOrderDto dto)
        {
            dto.OrderId = id;
            try
            {
                _editOrder.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje podataka odredjene porudzbine po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteOrder.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
