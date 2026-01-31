using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    /// <summary>
    /// Controlador responsáveç pela gestão das categorias de eventos no calendário pessoal.
    /// Permite criar e listar categorias através de uma API REST.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Caminho do ficheiro JSON onde as categorias são guardadas.
        /// Este ficheiro funciona como "base de dados" simples.
        /// </summary>
        private readonly string file = "categories.json";

        /// <summary>
        /// Obtém todas as categorias existentes.
        /// </summary>
        /// <returns>Lista de categorias em formato JSON.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Carrega todas as categorias do ficheiro JSON.
            return Ok(FileStorage.Load<Category>(file));
        }

        /// <summary>
        /// Cria uma nova categoria e guarda-a no ficheiro JSON.
        /// </summary>
        /// <param name="category">Objeto Category enviado no corpo do pedido.</param>
        /// <returns>A categoria criada, incluindo o ID atribuído</returns>
        [HttpPost]
        public IActionResult Post(Category category)
        {
            //Carrega a lista atual de categorias.
            var list = FileStorage.Load<Category>(file);
            //Gera um novo ID incremental.
            category.Id = list.Count > 0 ? list.Max(c => c.Id) + 1 : 1;

            //Adiciona a nova categoria à lista.
            list.Add(category);
            //Guarda a lista atualizada no ficheiro JSON.
            FileStorage.Save(file, list);

            //Retorna a categoria criada.
            return Ok(category);
        }
    }
}
