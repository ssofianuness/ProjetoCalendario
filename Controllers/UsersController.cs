using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    /// <summary>
    /// Controlador responsável pela gestão dos utilizadores.
    /// Permite criar utilizadores, criar novos e efetuar login.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Caminho do ficheiro JSON onde os utilizadores são guardados.
        /// Este ficheiro funciona como "base de dados" simples.
        /// </summary>
        private readonly string file = "users.json";

        /// <summary>
        /// Obtém todos os utilizadores existentes.
        /// </summary>
        /// <returns>Lista de utilizadores em formato JSON.</returns>
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            //Carrega todos os utilizadores do ficheiro JSON.
            var list = FileStorage.Load<User>(file);
            return Ok(list);
        }

        /// <summary>
        /// Cria um novo utilizador no sistema.
        /// </summary>
        /// <param name="user">Objeto User enviado no corpo do pedido.</param>
        /// <returns>O utilizador criado, incluindo o ID atribuído.</returns>
        // POST api/users (criar utilizador)
        [HttpPost]
        public IActionResult Post(User user)
        {
            //Carrega a lista atual de utilizadores.
            var list = FileStorage.Load<User>(file);

            //Gera um novo ID incremental.
            user.Id = list.Count > 0 ? list.Max(u => u.Id) + 1 : 1;

            //Adiciona o novo utilizador à lista.
            list.Add(user);
            //Guarda a lista atualizada no ficheiro JSON.
            FileStorage.Save(file, list);

            //Retorna o utilizador criado.
            return Ok(user);
        }

        /// <summary>
        /// Verifica as credenciais de login do utilizador (email + password).
        /// </summary>
        /// <param name="credentials">Objeto contendo email e password.</param>
        /// <returns>O utilizador autenticado ou errop 401 se falhar.</returns>
        // POST api/users/login  (verifica email + password)
        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        {
            //Carrega a lista atual de utilizadores.
            var list = FileStorage.Load<User>(file);

            //Procura um utilizador que corresponda às credenciais fornecidas.
            var user = list.FirstOrDefault(u =>
                u.Email == credentials.Email &&
                u.Password == credentials.Password
            );

            //Se não encontrado, devolve erro de autenticação.
            if (user == null)
                return Unauthorized("Credenciais inválidas");

            //Login bem-sucedido, retorna o utilizador.
            return Ok(user);
        }
    }
}
