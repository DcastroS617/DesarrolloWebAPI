using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Alimento
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength:30, ErrorMessage ="No se puede ingresar", MinimumLength =1)]
        [Display(Name = "Tipo de Alimento")]
        public string Tipo_Alimento { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "No se puede ingresar", MinimumLength = 1)]
        [Display(Name = "Titulo de Alimento")]
        public string Titulo_Alimento { get; set; }
        [Display(Name = "Precio del Alimento")]
        public double Precio_Alimento { get; set; }
        public int ProveedorId { get; set; }
        public int? ArchivoId { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Archivo Archivo { get; set; }
    }
}
