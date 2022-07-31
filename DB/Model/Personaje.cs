
using DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB
{
    public class Personaje
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonajeID { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Historia { get; set; }
        public virtual ICollection<Pelicula>? Peliculas { get; set; }
        public virtual List<PeliculaPersonaje>? PeliculasPersonajes { get; set; }
    }
}
