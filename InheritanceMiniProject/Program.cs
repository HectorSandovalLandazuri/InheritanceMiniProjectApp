﻿// See https://aka.ms/new-console-template for more information


List<IRentable> rentables = new List<IRentable>();
List<IPurchasable> purchasables = new List<IPurchasable>();

var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia Optima" };
var book = new BookModel { NumberOfPages = 250, ProductName = "A Tale of Two Cities" };
var excavator=new ExcavatorModel { ProductName = "Bulldozer",QuantityInStock=2 };
rentables.Add(vehicle);
rentables.Add(excavator);
purchasables.Add(book);
purchasables.Add(vehicle);

Console.Write("Do you want to rent or purchase something (rent, purchase)?");
string rentalDecision=Console.ReadLine();
if (rentalDecision.ToLower()=="rent")
{
    foreach(IRentable rentable in rentables)
    {
        Console.WriteLine($"Item: {rentable.ProductName}");
        Console.WriteLine("Do you want to rent this item (yes/no)?");
        string wantToRent = Console.ReadLine();
        if (wantToRent.ToLower() == "yes")
        {
            rentable.Rent();
        }
        Console.WriteLine("Do you want to return this item (yes/no)?");
        string wantToReturn = Console.ReadLine();
        if (wantToReturn.ToLower() == "yes")
        {
            rentable.ReturnRental();
        }


    }
}

public interface IInventoryItem
{
    string ProductName { get; set; }
    int QuantityInStock { get; set; }

}

public interface IRentable:IInventoryItem
{
    void Rent();
    void ReturnRental();
}

public interface IPurchasable:IInventoryItem
{
    void Purchase();
}

public class InventoryItemModel:IInventoryItem
{
    public string ProductName { get; set; }
    public int QuantityInStock { get; set; }

}

public class VehicleModel:InventoryItemModel,IPurchasable,IRentable
{
    public decimal DealerFee { get; set; }

    public void Purchase()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This Vehicle has been purchased.");
    }

    public void Rent()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This Vehicle has been rented.");
    }

    public void ReturnRental()
    {
        QuantityInStock += 1;
        Console.WriteLine("This vehicle has been returned");
    }
}

public class BookModel : InventoryItemModel, IPurchasable
{
    public int NumberOfPages { get; set; }

    public void Purchase()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This book has been purchased.");
    }
}

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
