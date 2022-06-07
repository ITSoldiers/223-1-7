using BLL;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Service _service;
        public UserController()
        {
            _service = new Service();
        }

        // GET api/<UserController>/5
        [HttpGet("{login}")]
        public UserDTO Get(string login, string password)
        {
            return _service.GetUser(login, password);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post(UserDTO user)
        {
            _service.AddUser(user);
        }
    }
}
