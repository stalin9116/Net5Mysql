using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net5Mysql.API.Models
{
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        [JsonIgnore]
        public ICollection<Vehiculo> Vehiculos { get; set; }

    }
}
