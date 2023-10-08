using Domain.Common;

namespace Domain.Models;

public class Sale : IEntity
{
    private decimal unitPrice { get; set; }
    private int quantity { get; set; }
    private decimal totalPrice { get; set; }

    public int Id { get; set; }

    public DateTime Date { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Product Product { get; set; }

    public decimal UnitPrice
    {
        get => unitPrice;
        set
        {
            unitPrice = value;
            UpdateTotalPrice();
        }
    }

    public int Quantity
    {
        get => quantity; set
        {
            quantity = value;
            UpdateTotalPrice();
        }
    }

    public decimal TotalPrice
    {
        get => totalPrice;
        private set { totalPrice = value; }
    }

    private void UpdateTotalPrice()
    {
        totalPrice = unitPrice * quantity;
    }
}