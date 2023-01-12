// See https://aka.ms/new-console-template for more information
public class BookModel : InventoryItemModel, IPurchasable
{
    public int NumberOfPages { get; set; }

    public void Purchase()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This book has been purchased.");
    }
}
