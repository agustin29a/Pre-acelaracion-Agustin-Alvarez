
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
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeliculaID { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public int Clasificacion { get; set; }
        public int GeneroID { get; set; }
        public virtual Genero? Genero { get; set; }
        public virtual ICollection<Personaje>? Personajes { get; set; }
        public virtual List<PeliculaPersonaje>? PeliculasPersonajes { get; set; }

    }
}
