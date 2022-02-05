using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Mysql.API.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string estado { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }


    }
}
