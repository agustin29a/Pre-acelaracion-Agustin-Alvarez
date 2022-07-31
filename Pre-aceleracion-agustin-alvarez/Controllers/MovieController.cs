using AutoMapper;
using DB;
using DB.DTO;
using DB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pre_aceleracion_agustin_alvarez.Controllers
{

    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IPeliculaService _pelicula;
        private readonly IMapper _mapper;

        public MovieController(IPeliculaService pelicula, IMapper mapper)
        {
            this._pelicula = pelicula;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("/movies")]
        public async Task<ActionResult> Get(string? nombre, int? idGenero, string? order)
        {
            if ((nombre == null || nombre == "") && (idGenero == null || idGenero == 0) && (order == null || order == ""))
            {
                var p = await _pelicula.GetAll();
                return Ok(_mapper.Map<IEnumerable<PeliculaDTO>>(p));
            }
            else
            {
                var p = await _pelicula.Search(nombre, idGenero, order);
                return Ok(_mapper.Map<IEnumerable<PeliculaDetailDTO>>(p));
            }

        }


        [HttpGet]
        [Route("/movie")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id == 0)
                return NotFound("Please, set an ID.");

            var pelicula = await _pelicula.GetById(id);
            return pelicula != null ? Ok(_mapper.Map<PeliculaDetailDTO>(pelicula)) : NotFound("User doesn't exists");
        }

      
        [HttpPost]
        [Route("/movie")]
        public async Task<ActionResult> Create(PeliculaInputDTO pelicula)
        {
            var _movie = _mapper.Map<Pelicula>(pelicula);
                _movie = await _pelicula.Insert(_movie);
            return Ok(_mapper.Map<PeliculaInputDTO>(_movie));
        }

        [HttpDelete]
        [Route("/movie")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                await _pelicula.Delete(id.Value);

                return Ok("User deleted successfully.");
            }
            catch (Exception)
            {
                return NotFound("User doesn't exists");
            }
        }
    }
}
