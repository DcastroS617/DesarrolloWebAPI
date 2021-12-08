using DesarrolloWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI
{
    public class Archivo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
        public string ubicacion { get; set; }

        public virtual ICollection<Articulo> Articulo { get; set; }
        public virtual ICollection<Alimento> Alimento { get; set; }
    }
}
