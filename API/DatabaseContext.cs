using API_Bus.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
	{

	}
	public DbSet<Medicament> Medicaments { get; set; }
}