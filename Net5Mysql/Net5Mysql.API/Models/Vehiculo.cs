using System.ComponentModel.DataAnnotations;

namespace Net5Mysql.API.Models
{
    public class Vehiculo
    {

        [Key]
        public int VehiculoId { get; set; }
        public string placa { get; set; }
        public string chasis { get; set; }
        public int year { get; set; }
        public string cilindraje { get; set; }
        public string motor { get; set; }
        public string estado { get; set; }
        public Marca Marca { get; set; }
        public int MarcaId { get; set; }
    }
}
