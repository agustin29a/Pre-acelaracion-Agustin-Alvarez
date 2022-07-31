using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services
{
    public interface IPersonajeService: IGenericService<Personaje>
    {
        Task<List<Personaje>> Search(string? nombre, int? edad, int? idMovie);
        Task AddMovie(int idPersonaje, int idPelicula);
    }
}
