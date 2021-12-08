using System;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
    }
}
