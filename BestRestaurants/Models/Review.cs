namespace BestRestaurants.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public int RestaurantId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public virtual Restaurant Restaurant { get; set; }
  }
}