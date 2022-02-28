namespace BulkyBook.Models.ViewModel;

public class OrderViewModel
{
    public OrderHeader OrderHeader { get; set; }
    public IEnumerable<OrderDetail> OrderDetail { get; set; }
}