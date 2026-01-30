using Microsoft.AspNetCore.Mvc;
using ProjetoCalendario.Models;
using ProjetoCalendario.Services;

namespace ProjetoCalendario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly string file = "categories.json";

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(FileStorage.Load<Category>(file));
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var list = FileStorage.Load<Category>(file);
            category.Id = list.Count > 0 ? list.Max(c => c.Id) + 1 : 1;

            list.Add(category);
            FileStorage.Save(file, list);

            return Ok(category);
        }
    }
}
