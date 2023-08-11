using Class03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("{index}")]
        public ActionResult<Book> GetSingle(int index)
        {
            try
            {
                if (index < 0)
                    return BadRequest("Index can not be negative number");

                Book book = StaticDb.Books[index];

                if (book == null)
                    return NotFound($"Note with index {index} not found!");

                return Ok(book);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team");
            }
        }

        [HttpGet("queryString")]
        public ActionResult<Book> GetSingleBook(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                    return BadRequest("Insert at least one query paramater");

                if (string.IsNullOrEmpty(author))
                    return Ok(StaticDb.Books.Where(x => x.Title.ToLower() == title!.ToLower()).ToList());

                if (string.IsNullOrEmpty(title))
                    return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower()).ToList());

                return Ok(StaticDb.Books.Where(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                    return BadRequest("You need to enter the both params");

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }

        [HttpPost("titles")] // why is this not working :D
        public ActionResult<List<string>> GetTitles([FromBody] List<Book> books)
        {
            try
            { 
                List<string> titles = new List<string>();

                foreach(Book book in books)
                {
                    titles.Add(book.Title);
                }

                return Ok(titles);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A server error occured, please contact the support team.");
            }
        }
    }
}
