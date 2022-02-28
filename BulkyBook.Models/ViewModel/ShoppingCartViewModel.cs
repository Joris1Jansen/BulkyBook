namespace BulkyBook.Models.ViewModel;

public class ShoppingCartViewModel
{
    public IEnumerable<ShoppingCart> ListCart { get; set; }

    public OrderHeader OrderHeader { get; set; }
}