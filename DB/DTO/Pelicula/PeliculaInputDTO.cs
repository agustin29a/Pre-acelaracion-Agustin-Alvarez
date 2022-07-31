using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DTO
{
    public class PeliculaInputDTO
    {
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public int Clasificacion { get; set; }
        public int GeneroID { get; set; }

    }
}
