using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.DataTransfer.UserDtos;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.Application.Searches;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGetUsersCommand _getUsers;
        private readonly IGetUserCommand _getUser;
        private readonly ICreateUserCommand _createUser;
        private readonly IEditUserCommand _editUser;
        private readonly IDeleteUserCommand _deleteUser;

        public UsersController(IGetUsersCommand getUsers, IGetUserCommand getUser, ICreateUserCommand createUser, IEditUserCommand editUser, IDeleteUserCommand deleteUser)
        {
            _getUsers = getUsers;
            _getUser = getUser;
            _createUser = createUser;
            _editUser = editUser;
            _deleteUser = deleteUser;
        }
        /// <summary>
        /// Dohvatanje svih korisnika sa filtracijom.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get([FromQuery] UserSearch search)
        {
            try
            {
                var users = _getUsers.Execute(search);
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Dohvatanje odredjenog korisnika po prosledjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            try
            {
                var user = _getUser.Execute(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Unos podataka korisnika.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody] CreateUserDto dto)
        {
            try
            {
                _createUser.Execute(dto);
                return StatusCode(201, "Uspesno ste uneli podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Izmena podataka korisnika po odredjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateUserDto dto)
        {
            dto.UserId = id;
            try
            {
                _editUser.Execute(dto);
                return StatusCode(201, "Uspesno ste izmenili podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
        /// <summary>
        /// Brisanje podataka korisnika po odredjenom kljucu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);
                return StatusCode(201, "Uspesno ste izbrisali podatke.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske, pokusajte ponovo.");
            }
        }
    }
}
