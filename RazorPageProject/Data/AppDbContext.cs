using Microsoft.EntityFrameworkCore;

public class AppDbContext: AppDbContext{
    public AppDbContext()(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Room> Rooms {get; set;}
}