// See https://aka.ms/new-console-template for more information


List<IRentable> rentables = new List<IRentable>();
List<IPurchasable> purchasables = new List<IPurchasable>();

var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Kia Optima" };
var book = new BookModel { NumberOfPages = 250, ProductName = "A Tale of Two Cities" };
var excavator=new ExcavatorModel { ProductName = "Bulldozer",QuantityInStock=2 };
rentables.Add(vehicle);
rentables.Add(excavator);
purchasables.Add(book);
purchasables.Add(vehicle);

Console.Write("Do you want to rent or purchase something (rent, purchase)? ");
string rentalDecision=Console.ReadLine();
if (rentalDecision.ToLower() == "rent")
{
    foreach (IRentable rentable in rentables)
    {
        Console.WriteLine($"Item: {rentable.ProductName}");
        Console.Write("Do you want to rent this item (yes/no)? ");
        string wantToRent = Console.ReadLine();
        if (wantToRent.ToLower() == "yes")
        {
            rentable.Rent();
        }
        Console.Write("Do you want to return this item (yes/no)? ");
        string wantToReturn = Console.ReadLine();
        if (wantToReturn.ToLower() == "yes")
        {
            rentable.ReturnRental();
        }
    }
}
else
{
    foreach (IPurchasable purchasable in purchasables)
    {
        Console.WriteLine($"Item: {purchasable.ProductName}");
        Console.Write("Do you want to purchase this item (yes/no)? ");
        string wantToPurchase = Console.ReadLine();
        if (wantToPurchase.ToLower() == "yes")
        {
            purchasable.Purchase();
        }
    }
}

Console.WriteLine("We are done.");
