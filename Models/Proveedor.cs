using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Alimento> Alimento { get; set; }
        public virtual ICollection<Articulo> Articulo { get; set; }
    }
}
