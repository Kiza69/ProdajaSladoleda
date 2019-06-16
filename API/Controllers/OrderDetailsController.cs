using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.DataTransfer.OrderDetailDtos;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IGetOrderDetailsCommand _getOrderDetails;
        private readonly IGetOrderDetailCommand _getOrderDetail;
        private readonly ICreateOrderDetailCommand _createOrderDetail;
        private readonly IEditOrderDetailCommand _editOrderDetail;
        private readonly IDeleteOrderDetailCommand _deleteOrderDetail;

        public OrderDetailsController(IGetOrderDetailsCommand getOrderDetails, IGetOrderDetailCommand getOrderDetail, ICreateOrderDetailCommand createOrderDetail, IEditOrderDetailCommand editOrderDetail, IDeleteOrderDetailCommand deleteOrderDetail)
        {
            _getOrderDetails = getOrderDetails;
            _getOrderDetail = getOrderDetail;
            _createOrderDetail = createOrderDetail;
            _editOrderDetail = editOrderDetail;
            _deleteOrderDetail = deleteOrderDetail;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IActionResult Get([FromQuery] OrderDetailSearch search)
        {
            try
            {
                var ods = _getOrderDetails.Execute(search);
                return Ok(ods);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje svih stavki porudzbine sa ugradjenom filtracijom po zadatim kriterijumima. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderDetailDto>> Get(int id)
        {
            try
            {
                var od = _getOrderDetail.Execute(id);
                return Ok(od);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos odredjene stavke.
        /// Stavka se ne moze uneti bez prethodno kreirane porudzbine.
        /// Ne mogu se proslediti nepostojeci kljucevi. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/OrderDetails
        [HttpPost]
        public ActionResult<OrderDetailDto> Post([FromBody] CreateOrderDetailDto dto)
        {
            try
            {
                _createOrderDetail.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka odredjene stavke, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateOrderDetailDto dto)
        {
            dto.OrderDetailId = id;
            try
            {
                _editOrderDetail.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje odredjene stavke, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteOrderDetail.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
