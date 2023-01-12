// See https://aka.ms/new-console-template for more information
public class ExcavatorModel : InventoryItemModel,IRentable
{
    public void Dig()
    {
        Console.WriteLine("I'm Digging");
    }

    public void Rent()
    {
        QuantityInStock-=1;
        Console.WriteLine("This excavator has been rented");
    }

    public void ReturnRental()
    {
        QuantityInStock += 1;
        Console.WriteLine("This excavator has been returned");
    }
}
