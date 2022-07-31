using DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implements
{
    public class PersonajeService: GenericService<Personaje>, IPersonajeService
    {
        private IPersonajeRepository _personajeRepository;
        public PersonajeService(IPersonajeRepository personajeRepository) : base(personajeRepository)
        {
            this._personajeRepository = personajeRepository;
        }

        public Task<List<Personaje>> Search(string? nombre, int? edad, int? idMovie)
        {
            return _personajeRepository.Search(nombre, edad, idMovie);
        }

        public async Task AddMovie(int idPersonaje, int idPelicula)
        {
            await _personajeRepository.AddMovie(idPersonaje, idPelicula);
        }


    }
}
