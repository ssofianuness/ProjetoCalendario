using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly string file = "events.json";

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(FileStorage.Load<Event>(file));
        }

        [HttpPost]
        public IActionResult Post(Event ev)
        {
            ev.Validate();

            var list = FileStorage.Load<Event>(file);
            ev.Id = list.Count > 0 ? list.Max(e => e.Id) + 1 : 1;

            list.Add(ev);
            FileStorage.Save(file, list);

            return Ok(ev);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var list = FileStorage.Load<Event>(file);
            var ev = list.FirstOrDefault(e => e.Id == id);

            if (ev == null)
                return NotFound();

            list.Remove(ev);
            FileStorage.Save(file, list);

            return Ok();
        }
    }
}
