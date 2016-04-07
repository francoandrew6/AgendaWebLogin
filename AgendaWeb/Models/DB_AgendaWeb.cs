using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AgendaWeb.Models
{
    public partial class DB_AgendaWeb:DbContext
    {
        public DB_AgendaWeb() : base("name=DB_AgendaWeb") { }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Contacto> contacto { get; set; }
    }
}