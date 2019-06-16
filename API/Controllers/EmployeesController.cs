using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.DataTransfer.EmployeeDtos;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployeesCommand _getEmployees;
        private readonly IGetEmployeeCommand _getEmployee;
        private readonly ICreateEmployeeCommand _createEmployee;
        private readonly IEditEmployeeCommand _editEmployee;
        private readonly IDeleteEmployeeCommand _deleteEmployee;

        public EmployeesController(IGetEmployeesCommand getEmployees, IGetEmployeeCommand getEmployee, ICreateEmployeeCommand createEmployee, IEditEmployeeCommand editEmployee, IDeleteEmployeeCommand deleteEmployee)
        {
            _getEmployees = getEmployees;
            _getEmployee = getEmployee;
            _createEmployee = createEmployee;
            _editEmployee = editEmployee;
            _deleteEmployee = deleteEmployee;
        }
        /// <summary>
        /// Dohvatanje svih zaposlenih sa ugradjenom filtracijom po zadatim kriterijumima.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get([FromQuery] EmployeeSearch search)
        {
            try
            {
                var employees = _getEmployees.Execute(search);
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjenog zaposlenog, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get(int id)
        {
            try
            {
                var employee = _getEmployee.Execute(id);
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos podataka za zaposlenog. Email se ne sme ponoviti.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Employees
        [HttpPost]
        public ActionResult Post([FromBody] CreateEmployeeDto dto)
        {
            try
            {
                _createEmployee.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka odredjenog zaposlenog, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateEmployeeDto dto)
        {
            dto.EmployeeId = id;
            try
            {
                _editEmployee.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje podataka odredjenog zaposlenog, po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteEmployee.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
