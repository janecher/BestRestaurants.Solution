namespace BestRestaurants
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public int CuisineId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual Restaurant Restaurant { get; set; }
  }
}