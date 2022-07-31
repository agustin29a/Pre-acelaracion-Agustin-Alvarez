using DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
	public class PersonajeRepository : BaseRepository<Personaje, ChallengeContext>, IPersonajeRepository
	{

		ChallengeContext _context;
		public PersonajeRepository(ChallengeContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Personaje>> Search(string? nombre, int? edad, int? idMovie)
		{
			IQueryable<Personaje> personajes = _context.Set<Personaje>();

			if (nombre != null && nombre != "")
			{
				try
				{
					personajes = personajes.Where(p => p.Nombre == nombre);


				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}

			if (edad != null && edad != 0)
			{
				try
				{
					personajes = personajes.Where(p => p.Edad == edad);


				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}

			}

            if (idMovie != null && idMovie != 0)
            {
				try
				{
					personajes = personajes.Where(c => c.Peliculas.Any(p => p.PeliculaID == idMovie));

				}
				catch (System.Exception ex)
				{
					throw new Exception(ex.Message);
				}

			}

			return await personajes.ToListAsync();

		}

		public async Task AddMovie(int idPersonaje, int idPelicula)
        {
            try
            {
				var personaje = _context.Set<Personaje>().Where(a => a.PersonajeID == idPersonaje).FirstOrDefault();
				var pelicula = _context.Set<Pelicula>().Where(a => a.PeliculaID == idPelicula).FirstOrDefault();

				if (personaje == null || pelicula == null)
				{
				   throw new Exception("The entity is null");
				}

				var peliculaPersonaje = new PeliculaPersonaje()
				{
					Personaje = personaje,
					Pelicula = pelicula				
                };

               await _context.AddAsync(peliculaPersonaje);
			   _context.SaveChanges();
			}
			catch (System.Exception ex)
			{
				throw new Exception(ex.Message);
			}


		}
	}
}
