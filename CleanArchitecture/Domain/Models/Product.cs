using Domain.Common;

namespace Domain.Models;

public class Product : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}