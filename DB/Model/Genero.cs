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
    public class Genero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneroID { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public virtual ICollection<Pelicula>? Peliculas { get; set; }
    }
}
