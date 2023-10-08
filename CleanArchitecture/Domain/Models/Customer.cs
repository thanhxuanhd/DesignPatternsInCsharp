using Domain.Common;

namespace Domain.Models;

public class Customer : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
}