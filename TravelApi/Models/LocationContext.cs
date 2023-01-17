using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
  public class TravelApiContext : DbContext
  {
    public DbSet<Location> Locations { get; set; }

    public TravelApiContext(DbContextOptions<TravelApiContext> options) : base(options)
    {
    }
  
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Location>()
      .HasData(
        new Location { LocationId = 1, Name = "Portland", Country = "United States", Description = "Modern, walkable city known for its food and beer culture", Walkability = 5, PublicTransit = 4, Rating = 5},
        new Location { LocationId = 2, Name = "Seattle", Country = "United States", Description = "Like Portland, but not as cool. Thinks it invented soccer.", Walkability = 3, PublicTransit = 4, Rating = 4},
        new Location { LocationId = 3, Name = "Berlin", Country = "Germany", Description = "The apex of human culture", Walkability = 5, PublicTransit = 5, Rating = 5},
        new Location { LocationId = 4, Name = "London", Country = "UK", Description = "Fish n' chips, innit", Walkability = 5, PublicTransit = 3, Rating = 5},
        new Location { LocationId = 5, Name = "Miami", Country = "United States", Description = "Really hot weather and hotter beaches", Walkability = 2, PublicTransit = 1, Rating = 3},
        new Location { LocationId = 6, Name = "Cleveland", Country = "United States", Description = "trust me, just don't", Walkability = 1, PublicTransit = 1, Rating = 1},
        new Location { LocationId = 7, Name = "Tokyo", Country = "Japan", Description = "Lots of people, little space", Walkability = 5, PublicTransit = 5, Rating = 4}
        
      );
  }
}
    