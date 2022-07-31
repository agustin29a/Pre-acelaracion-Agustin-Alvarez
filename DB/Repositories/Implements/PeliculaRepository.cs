using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DB.Repositories.Implements
{
    public class PeliculaRepository : BaseRepository<Pelicula, ChallengeContext>, IPeliculaRepository
    {
		ChallengeContext _context;
		public PeliculaRepository(ChallengeContext context) : base(context)
        {
			_context = context;
		}

		public async Task<List<Pelicula>> Search(string? nombre, int? idGenero, string? order)
		{
			IQueryable<Pelicula> peliculas = _context.Set<Pelicula>();

			if (nombre != null && nombre != "")
			{
				try
				{
					peliculas = peliculas.Where(p => p.Titulo == nombre);


				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}

			if (idGenero != null && idGenero != 0)
			{
				try
				{
					peliculas = peliculas.Where(p => p.GeneroID == idGenero);


				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}

			}

			if (order != null && order != "" && order.ToUpper() != "ASC")
			{
                try
                {
					peliculas = peliculas.OrderBy(p => p.FechaDeCreacion);

                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
			else if (order != null && order != "" && order.ToUpper() != "DESC")
            {
				try
				{
					peliculas = peliculas.OrderBy(p => p.FechaDeCreacion);

				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}

			return await peliculas.ToListAsync();

		}
	}
}
