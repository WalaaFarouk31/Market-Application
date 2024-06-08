using System.ComponentModel.DataAnnotations;

namespace MarketApplication.Core.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Boolean IsActive { get; set; } = true;
    public virtual Category Category { get; set; }
    public int CategoryId { get; set; }
}
