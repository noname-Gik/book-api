using bookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Books> books = new List<Books>
            {
                new Books {id =1, name="1984", date= new DateTime(1999,7, 7, 12, 0, 0) },
                new Books {id =2, name="Архипелаг Гулаг", date= new DateTime(1984,3, 2, 12, 45, 0) }
            };

        [HttpGet]
        public async Task<ActionResult<List<Books>>> GET()
        {
            return Ok(books);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Books>> GET(string name)
        {
            var book = books.Where(b=> b.name!.Contains(name));
            if (book == null)
                return BadRequest("Ничего не найдено");
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Books>>> ADD(Books book)
        {
            books.Add(book);
            return Ok(books);
        }

        [HttpPut]
        public async Task<ActionResult<List<Books>>> UPDATE(Books request)
        {
            var dbbook = books.Find(b => b.id == request.id);
            if (dbbook == null)
                return BadRequest("Ничего не найдено");

            dbbook.name = request.name;

            return Ok(books);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Books>>> DELETE(int id)
        {
            var dbbook = books.Find(b => b.id == id);
            if (dbbook == null)
                return BadRequest("Ничего не найдено");

            books.Remove(dbbook);
            return Ok(books);
        }

    }
}

