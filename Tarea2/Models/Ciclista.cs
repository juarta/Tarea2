	using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea2.Models
{
    public class Ciclista
    {

        [Required(ErrorMessage = "El campo Id es requerido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string Apellido { get; set; }

        public TimeSpan Tiempo { get; set; }
        public double Velocidad { get; set; }


        [Required(ErrorMessage = "El campo minutos es requerido.")]
        [Range(0, 60, ErrorMessage = "El valor del campo minutos debe estar entre 0 y 60.")]
        public int Minutos { get; set; }

        [Required(ErrorMessage = "El campo segundos es requerido.")]
        [Range(0, 60, ErrorMessage = "El valor del campo segundos debe estar entre 0 y 60.")]
        public int Segundos { get; set; }
    }

}