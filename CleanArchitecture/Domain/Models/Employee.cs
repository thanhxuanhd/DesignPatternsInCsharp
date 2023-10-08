using Domain.Common;

namespace Domain.Models;

public class Employee : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
}
