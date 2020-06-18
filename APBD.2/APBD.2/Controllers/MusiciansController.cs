using APBD._2.Exceptions;
using APBD._2.Models;
using APBD._2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD._2.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IMusicDbService _dbService;

        public MusiciansController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetArtist(int id)
        {
            try
            {
                var data =_dbService.GetArtist(id);

                return Ok(data);
            }
            catch (MusicLabelDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{idArtist:int")]
        public IActionResult UpdateMusicLabel([FromBody] ArtistRequest request)
        {
            try
            {
                _dbService.UpgradeDate(request);

                return Ok();
            }
            catch (MusicLabelDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}