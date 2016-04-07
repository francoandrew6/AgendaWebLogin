using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AgendaWeb.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Nombre Requerido")]
        public String nombre { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Correo Requerido"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Contraseña Obligatoria"), DataType(DataType.Password)]
        [StringLength(10, MinimumLength=8, ErrorMessage="La contraseña debe tener 10 caracteres")]
        public String contraseña { get; set; }
        [Display(Name = "Comparar Contraseña"), Required(ErrorMessage = "Contraseña Obligatoria"), DataType(DataType.Password)]
        [Compare("contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        public String compararContraseña { get; set; }

        public virtual List<Contacto> contactos { get; set; }
        public virtual Rol rol{get;set;}

    }

}