using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.DTO
{
    public class PersonajeDetailDTO
    {
        public int PersonajeID { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Historia { get; set; }
        public virtual ICollection<PeliculaDTO>? Peliculas { get; set; }

    }
}
