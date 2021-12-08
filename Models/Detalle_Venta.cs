using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesarrolloWebAPI.Models
{
    public class Detalle_Venta
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public double Total_Ganancia { get; set; }
        public double Total_Venta { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
