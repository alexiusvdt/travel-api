namespace TravelApi.Models
{
  public class Location
  {
    public int LocationId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Description { get; set; }
    public int Walkability { get; set; }
    public int PublicTransit { get; set; }
    public int Rating { get; set; }
  }
}