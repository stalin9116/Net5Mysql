// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net5Mysql.API.Models;

namespace Net5Mysql.API.Migrations
{
    [DbContext(typeof(ContextCarrito))]
    [Migration("20220205015913_ModelUserRol")]
    partial class ModelUserRol
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Net5Mysql.API.Models.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .HasColumnType("text");

                    b.Property<string>("clave")
                        .HasColumnType("text");

                    b.Property<string>("correo")
                        .HasColumnType("text");

                    b.Property<string>("estado")
                        .HasColumnType("text");

                    b.Property<string>("nombres")
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("chasis")
                        .HasColumnType("text");

                    b.Property<string>("cilindraje")
                        .HasColumnType("text");

                    b.Property<string>("estado")
                        .HasColumnType("text");

                    b.Property<string>("motor")
                        .HasColumnType("text");

                    b.Property<string>("placa")
                        .HasColumnType("text");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("VehiculoId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Usuario", b =>
                {
                    b.HasOne("Net5Mysql.API.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Vehiculo", b =>
                {
                    b.HasOne("Net5Mysql.API.Models.Marca", "Marca")
                        .WithMany("Vehiculos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Marca", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Net5Mysql.API.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
