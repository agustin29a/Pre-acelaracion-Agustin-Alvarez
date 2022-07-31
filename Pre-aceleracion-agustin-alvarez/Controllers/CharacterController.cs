using AutoMapper;
using DB;
using DB.DTO;
using DB.DTO.Personaje;
using DB.Repositories;
using DB.Services;
using DB.Services.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pre_aceleracion_agustin_alvarez.Controllers
{
 
    [ApiController]
    [Authorize]
    public class CharacterController : ControllerBase
    {
        
        private readonly IPersonajeService _personaje;
        private readonly IMapper _mapper;

        public CharacterController(IPersonajeService personaje , IMapper mapper)
        {
            this._personaje = personaje;
            this._mapper = mapper; 
        }

       
        [HttpGet]
        [Route("/character")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id == 0)
                return NotFound("Please, set an ID.");

            var personaje = await _personaje.GetById(id);
            return personaje != null ? Ok(_mapper.Map<PersonajeDetailDTO>(personaje)) : NotFound("User doesn't exists");
        }

        [HttpGet]
        [Route("/characters")]
        public async Task<ActionResult> GetBySearch(string? nombre, int? edad, int? idMovie)
        {
            if ((nombre == null || nombre == "") && (edad == null || edad == 0) && (idMovie == null || idMovie == 0))
            {
                var p = await _personaje.GetAll();
                return Ok(_mapper.Map<IEnumerable<PersonajeDTO>>(p));
            }
            else
            {
                var personaje = await _personaje.Search(nombre, edad, idMovie);
                return Ok(_mapper.Map<IEnumerable<PersonajeDetailDTO>>(personaje));
            }
            
        }

        [HttpPost]
        [Route("/character")]
        public async Task<ActionResult> Create(PersonajeInputDTO personaje)
        {
             var _character = _mapper.Map<Personaje>(personaje);
             _character = await _personaje.Insert(_character);
            return Ok(_mapper.Map<PersonajeInputDTO>(_character));
        }

        [HttpPut]
        [Route("/character")]
        public async Task<ActionResult> Edit(Personaje personaje)
        {
            if (ModelState.IsValid)
            {
                personaje = await _personaje.Update(personaje);
            }
            return Ok(personaje);
        }


        [HttpDelete]
        [Route("/character")]
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                await _personaje.Delete(id.Value);

                return Ok("User deleted successfully.");
            }
            catch (Exception)
            {
                return NotFound("User doesn't exists");
            }
        }

        [HttpPost]
        [Route("/character/addMovie")]
        public async Task<ActionResult> AddMovie(int idPersonaje, int idPelicula)
        {   
            return Ok(_personaje.AddMovie(idPersonaje, idPelicula));
        }

    }
}
