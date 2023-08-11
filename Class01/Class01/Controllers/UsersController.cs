using Microsoft.AspNetCore.Mvc;

namespace Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.Usernames);
        }

        [HttpGet("{id}")]
        public ActionResult<List<string>> GetById(int id)
        {
            try
            {
                if (id < 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "The id is a negative number");

                if (id >= StaticDb.Usernames.Count)
                    return StatusCode(StatusCodes.Status404NotFound, $"The note with id {id} was not found");

                return Ok(StaticDb.Usernames[id]);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error ocured. Contact the support team");
            }
        }
    }
}
