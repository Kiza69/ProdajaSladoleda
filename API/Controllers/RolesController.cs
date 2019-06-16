using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.DataTransfer.RoleDtos;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRolesCommand _getRoles;
        private readonly IGetRoleCommand _getRole;
        private readonly ICreateRoleCommand _createRole;
        private readonly IEditRoleCommand _editRole;
        private readonly IDeleteRoleCommand _deleteRole;

        public RolesController(IGetRolesCommand getRoles, IGetRoleCommand getRole, ICreateRoleCommand createRole, IEditRoleCommand editRole, IDeleteRoleCommand deleteRole)
        {
            _getRoles = getRoles;
            _getRole = getRole;
            _createRole = createRole;
            _editRole = editRole;
            _deleteRole = deleteRole;
        }
        /// <summary>
        /// Dohvatanje svih uloga korisnika.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> Get([FromQuery] RoleSearch search)
        {
            try
            {
                var roles = _getRoles.Execute(search);
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjene uloge korisnika po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public ActionResult<RoleDto> Get(int id)
        {
            try
            {
                var role = _getRole.Execute(id);
                return Ok(role);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos podataka uloge korisnika.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Roles
        [HttpPost]
        public ActionResult Post([FromBody] CreateRoleDto dto)
        {
            try
            {
                _createRole.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka uloge korisnika po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateRoleDto dto)
        {
            dto.RoleId = id;
            try
            {
                _editRole.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje podataka uloge korisnika po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteRole.Execute(id);
                return StatusCode(201, "Uspesno ste obrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
