using DB.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services.Implements
{
    public class PeliculaService: GenericService<Pelicula>, IPeliculaService
    {
        private IPeliculaRepository _peliculaRepository;
        public PeliculaService(IPeliculaRepository peliculaRepository) : base(peliculaRepository)
        {
            this._peliculaRepository = peliculaRepository;
        }

        public Task<List<Pelicula>> Search(string? nombre, int? idGenero, string? order)
        {
            return _peliculaRepository.Search(nombre, idGenero, order);
        }
    }
}
