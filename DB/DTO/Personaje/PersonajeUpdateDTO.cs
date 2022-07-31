using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DTO.Personaje
{
    public class PersonajeUpdateDTO
    {
        public int PersonajeID { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Historia { get; set; }
       
    }
}
