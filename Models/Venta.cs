using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public int? AlimentoId { get; set; }
        public int? ArticuloId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Alimento Alimento { get; set; }
        public virtual Articulo Articulo { get; set; }
        public virtual Usuario Usuario { get; set; }
        //public ICollection<Detalle_Venta> Detalle_Venta { get; set; }
    }
}
