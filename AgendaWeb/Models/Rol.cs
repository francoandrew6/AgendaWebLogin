using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre Obligatorio")]
        public String nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Descripcion obligatorio")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }


    }
}