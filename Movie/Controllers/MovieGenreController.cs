using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Movie.Repository;

namespace Movie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieGenreController : ControllerBase
    {
       IPostRepository postRepository { get; set; }
        public MovieGenreController(IPostRepository _postrepository)
        { postRepository = _postrepository; }

        [HttpGet]
        [Route("GetMovie")]
        public async Task<IActionResult> GetMovies([FromQuery]string genre)
        {
            if(genre==null)
            { return BadRequest(); }
            
            try
            {   var genres=await postRepository.GetGenre(genre);
                if (genres != null)
                {
                    var movie = await postRepository.GetMovies(genres);
                    if (postRepository == null)
                    {
                        return NotFound();
                    }
                    return Ok(movie);
                }
                else { return BadRequest("Genre not found"); }
               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }



            
        }
    }
}