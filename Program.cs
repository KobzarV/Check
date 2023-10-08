struct Item
{
    public string Name;
    public int Quantity;
    public double PricePerUnit;
    public double Discount;
}

struct Check
{
    private List<Item> items;

    public Check(int capacity)
    {
        items = new List<Item>(capacity);
    }

    public void AddItem(string name, int quantity, double pricePerUnit, double discount)
    {
        Item item = new Item
        {
            Name = name,
            Quantity = quantity,
            PricePerUnit = pricePerUnit,
            Discount = discount
        };
        items.Add(item);
    }

    public void PrintCheck()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WindowWidth = 60; // Ширина консольного вікна

        Console.WriteLine("*******************************************************");
        Console.WriteLine("*                      Магазин \"Peny\"                 *");
        Console.WriteLine("*******************************************************");
        Console.WriteLine("Назва          Кількість    Ціна   Знижки   Ціна       ");
        Console.WriteLine("-------------------------------------------------------");

        double total = 0;
        foreach (var item in items)
        {
            double discountAmount = item.PricePerUnit * item.Discount;
            double totalPrice = item.PricePerUnit * item.Quantity - discountAmount;
            total += totalPrice;

            Console.WriteLine($"{item.Name,-5} {item.Quantity,10} {item.PricePerUnit,10:C}" +
                $" {item.Discount,7:P} {totalPrice,8:C}    ");
        }

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine($"{"До сплати:",46} {total}  ");
        Console.WriteLine("*******************************************************");

        Console.ResetColor();
    }
}

class Program
{
    static void Main()
    {
        Check check = new Check(10);
        check.AddItem("Товар1", 2, 10.99, 0.05);
        check.AddItem("Товар2", 1, 5.99, 0.10);
        check.AddItem("Товар3", 3, 7.49, 0.15);

        check.PrintCheck();
    }
}
