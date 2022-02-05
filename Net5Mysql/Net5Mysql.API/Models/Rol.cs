using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Mysql.API.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
