using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Models
{
    public class Contacto
    {
        [Key]
        public int idContacto { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Nombre Requerido")]
        public String nombreContacto { get; set; }
        [Display(Name = "Telefono"), Required(ErrorMessage = "Telefono Requerido"), DataType(DataType.PhoneNumber)]
        public int telefonoCasa { get; set; }
        [Display(Name = "Movil"), DataType(DataType.PhoneNumber)]
        public int telefonoMovil { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Correo Requerido"), DataType(DataType.EmailAddress)]
        public String correoContacto { get; set; }
        [Display(Name = "Direccion"), Required(ErrorMessage = "Direccion Requerida"), DataType(DataType.Text)]
        public String direccion { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}