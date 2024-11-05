using Microsoft.EntityFrameworkCore;

public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }          // Conjunto de habitaciones
    public DbSet<Reservation> Reservations { get; set; } // Conjunto de reservas
    public DbSet<ApplicationUser> Users { get; set; } // Conjunto de usuarios (si estás usando Identity)
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aquí puedes configurar más detalles sobre tu modelo si es necesario
        modelBuilder.Entity<Room>()
            .Property(r => r.Price)
            .HasColumnType("decimal(18,2)"); // Configura el tipo de columna para el precio

        // Puedes agregar más configuraciones para tus modelos si es necesario
    }
}
