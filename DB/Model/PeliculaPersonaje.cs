using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    public class PeliculaPersonaje
    {
        public int PersonajeId { get; set; }
        public virtual Personaje Personaje { get; set; }

        public int PeliculaId { get; set; }
        public virtual Pelicula Pelicula { get; set; }
    }
}
