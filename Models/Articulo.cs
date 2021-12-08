using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "No se puede ingresar", MinimumLength = 1)]
        [Display(Name = "Nombre del Articulo")]
        public string Nombre_Articulo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "No se puede ingresar", MinimumLength = 1)]
        [Display(Name = "Tipo de Articulo")]
        public string Tipo_Articulo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Precio del Articulo")]
        public double Precio_Articulo { get; set; }
        public int ProveedorId { get; set; }
        public int? ArchivoId { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual Archivo Archivo { get; set; }
    }
}
