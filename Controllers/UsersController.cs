using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly string file = "users.json";

        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            var list = FileStorage.Load<User>(file);
            return Ok(list);
        }

        // POST api/users (criar utilizador)
        [HttpPost]
        public IActionResult Post(User user)
        {
            var list = FileStorage.Load<User>(file);

            user.Id = list.Count > 0 ? list.Max(u => u.Id) + 1 : 1;

            list.Add(user);
            FileStorage.Save(file, list);

            return Ok(user);
        }

        // POST api/users/login  (verifica email + password)
        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        {
            var list = FileStorage.Load<User>(file);

            var user = list.FirstOrDefault(u =>
                u.Email == credentials.Email &&
                u.Password == credentials.Password
            );

            if (user == null)
                return Unauthorized("Credenciais inválidas");

            return Ok(user);
        }
    }
}
