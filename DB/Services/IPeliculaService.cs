using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Services
{
    public interface IPeliculaService: IGenericService<Pelicula>
    {
        Task<List<Pelicula>> Search(string? nombre, int? idGenero, string? order);
    }
}
