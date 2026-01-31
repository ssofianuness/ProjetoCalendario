using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    /// <summary>
    /// Controlador responsável pela gestão dos eventos no calendário pessoal.
    /// Permite criar, listar e eliminar eventos através de uma API REST.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Caminho do ficheiro JSON onde os eventos são guardados.
        /// Este ficheiro funciona como "base de dados" simples.
        /// </summary>
        private readonly string file = "events.json";

        /// <summary>
        /// Devolve todos os eventos existentes.
        /// </summary>
        /// <returns>Lista de eventos em formato JSON.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Carrega todos os eventos do ficheiro JSON.
            return Ok(FileStorage.Load<Event>(file));
        }

        /// <summary>
        /// Cria um novo evento no sistema.
        /// Valida o evento antes de o guardar.
        /// </summary>
        /// <param name="ev">Objeto Event enviado no corpo do pedido.</param>
        /// <returns>O evento criado, incluindo o ID atribuído.</returns>
        [HttpPost]
        public IActionResult Post(Event ev)
        {
            //Valida regras básicas.
            ev.Validate();

            //Carrega a lista atual de eventos.
            var list = FileStorage.Load<Event>(file);
            //Gera um novo ID incremental.
            ev.Id = list.Count > 0 ? list.Max(e => e.Id) + 1 : 1;

            //Adiciona o novo evento à lista.
            list.Add(ev);
            //Guarda a lista atualizada no ficheiro JSON.
            FileStorage.Save(file, list);

            //Retorna o evento criado.
            return Ok(ev);
        }

        /// <summary>
        /// Elimina um evento pelo seu ID fornecido.
        /// </summary>
        /// <param name="id">ID do evento a eliminar.</param>
        /// <returns>Resposta HTTP indicando sucesso ou erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Carrega a lista atual de eventos.
            var list = FileStorage.Load<Event>(file);
            //Procura o evento pelo ID.
            var ev = list.FirstOrDefault(e => e.Id == id);

            //Se não encontrado, retorna 404.
            if (ev == null)
                return NotFound();

            //Remove o evento da lista.
            list.Remove(ev);
            //Guarda a lista atualizada no ficheiro JSON.
            FileStorage.Save(file, list);

            //Retorna sucesso.
            return Ok();
        }
    }
}
