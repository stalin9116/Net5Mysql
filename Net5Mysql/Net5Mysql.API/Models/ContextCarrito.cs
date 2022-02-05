using Microsoft.EntityFrameworkCore;

namespace Net5Mysql.API.Models
{
    public class ContextCarrito : DbContext
    {
        public ContextCarrito()
        {

        }

        public ContextCarrito(DbContextOptions<ContextCarrito> options)
            :base (options)
        {

        }

        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }



    }
}
