using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersTable.BLL.ModelsDTO;
using UsersTable.BLL.Services;
using UsersTable.BLL.Services.Interfaces;
using UsersTable.DAL.Models;

namespace UsersTable.Controllers
{
    [ApiController]
    [Route(LocalApiControllerConsts.StandardRoute)]
    public class HomeController : Controller
    {
        private IUserServices _userServices;

        public HomeController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest(user);
            }
            else
            {
                var newUser = await _userServices.CreateUserAsync(user);
                return Ok(newUser);
            }
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = GetUser(id);
            if (user == null)
            {
                return NotFound(user);
            }
            else
            {
                return Ok(await _userServices.DeleteAsync(id));
            }
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userServices.GetUsers();
            if (users.Count() == 0)
            {
                return NotFound(users);
            }
            else
            {
                return Ok(users);
            }
        }

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _userServices.GetAsync(id);
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// Get active users count.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ActiveUsers")]
        public async Task<IActionResult> GetActiveUsersCountAsync()
        {
            var users = await _userServices.GetActiveUsers();
            if (users.Count() == 0)
            {
                return NotFound(users);
            }
            else
            {
                return Ok(users.Count());
            }
        }

        /// <summary>
        /// Activate user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Activate/{id}")]
        public async Task<IActionResult> ActivateUser([FromRoute]int id)
        {
            var result = await _userServices.ActivateUser(id);
            if(result == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// DisActivate user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("DisActivate/{id}")]
        public async Task<IActionResult> DisActivateUser([FromRoute] int id)
        {
            var result = await _userServices.DisActivateUser(id);
            if (result == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }


    }
}
