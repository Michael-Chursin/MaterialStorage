double finances = 1000000.00;
List<Product> table = new List<Product>();
String input = "";
while (input != "0")
{
    String name;
    int amount;
    Console.WriteLine("Welcome to the Storage App.\n0 - exit\n1 - get information of products\n2 - buy products\n3 - sell products\n4 - set price on selected product\n5 - see my balance");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            foreach(Product p in table)
            {
                p.FullInfoPrint();
            }
            break;
        case "2":
            Console.WriteLine("Input name of product, you want to buy");
            name = Console.ReadLine();
            Console.WriteLine("Input amount of product, you want to buy");
            amount = Convert.ToInt32(Console.ReadLine());
            Buy(name, amount);
            break;
        case "3":
            Console.WriteLine("Input name of product, you want to sell");
            name = Console.ReadLine();
            Console.WriteLine("Input amount of product, you want to sell");
            amount = Convert.ToInt32(Console.ReadLine());
            Product product = FindByName(name);
            if (product != null)
            {
                Sell(product, amount);
            }
            else
            {
                Console.WriteLine("There is no such an item in storage");
            }
            break;
        case "4":
            Console.WriteLine("Input name of product");
            name = Console.ReadLine();
            Product selectedP = FindByName(name);
            break;
        case "5":
            Console.WriteLine($"Your balanse: {finances}$");
            break;
        default:
            break;
    }
    Console.WriteLine();
}
//Находим продукт по имени
Product FindByName(string name)
{
    Product product = null;
    for (int i = 0; i < table.Count; i++)
    {
        if (table[i].getName() == name)
        {
            return table[i];
        }
    }
    return null;
}
void Sell(Product p, int amount)
{
    int startAmount = p.getAmount();
    if (startAmount > amount)
    {
        finances = finances + Convert.ToDouble(amount) * p.getPrice();
        p.setAmount(startAmount - amount);
    }
    else
    {
        Console.WriteLine("There is not enough of an item in storage");
    }
}
void Buy(String name, int amount)
{
    Product p = FindByName(name);
    if (p != null)
    {
        BuyExisting(p, amount);
        return;
    }
    Console.WriteLine("There is no such product in table. Write the values of the product");
    Console.WriteLine("Write description of the product");
    String desc = Console.ReadLine();
    if (desc == null) {
        desc = "";
    }
    Console.WriteLine("Write length of the product");
    double l = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Write width of the product");
    double w = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Write height of the product");
    double h = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Write price of the product");
    double pr = Convert.ToDouble(Console.ReadLine());
    p = new Product(table.Count + 1, name, desc, l, w, h, pr, 0);
    BuyNew(p, amount);
    table.Add(p);
}
void BuyExisting(Product p, int amount)
{
    double fullPrice = Convert.ToDouble(amount) * p.getPrice();
    if (finances > fullPrice)
    {
        finances = finances - fullPrice;
        p.setAmount(p.getAmount() + amount);
    }
    else {
        Console.WriteLine("You have not enough money for this");
    }
}
void BuyNew(Product p, int amount)
{
    double fullPrice = Convert.ToDouble(amount) * p.getPrice();
    if (finances > fullPrice)
    {
        finances = finances - fullPrice;
        p.setAmount(amount);
    }
    else
    {
        Console.WriteLine("You have not enough money for this");
    }
}
public class Product
{
    private int id;
    private String Name;
    private String Description;
    private double Length;
    private double Width;
    private double Height;
    private double Price;
    private int Amount;
    public Product(int i, String n, String d, double l, double w, double h, double p, int a) {
        id = i;
        Name = n;
        Description = d;
        Length = l;
        Width = w;
        Height = h;
        Price = p;
        Amount = a;
    }
    public int getID()
    {
        return id;
    }
    public String getName()
    {
        return Name;
    }
    public String getDescription() {
        return Description;
    }
    public double getLength()
    {
        return Length;
    }
    public double getWidth()
    {
        return Width;
    }
    public double getHeight()
    {
        return Height;
    }
    public double getPrice()
    {
        return Price;
    }
    public int getAmount()
    {
        return Amount;
    }
    public void setName(String name)
    {
        this.Name = name;
    }
    public void setDescription(String description)
    {
        this.Description = description;
    }
    public void setLength(double length)
    {
        this.Length = length;
    }
    public void setWidth(double width)
    {
        this.Width = width;
    }
    public void setHeight(double height)
    {
        this.Height = height;
    }
    public void setPrice(double price)
    {
        this.Price = price;
    }
    public void setAmount(int amount)
    {
        if (amount > 0)
        {
            this.Amount = amount;
        }
        else
        {
            this.Amount = 0;
        }
    }
    public void FullInfoPrint()
    {
        Console.WriteLine("***********************************");
        Console.WriteLine(id);
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Length: {Length}");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Amount: {Amount}");
        Console.WriteLine("***********************************");
        Console.WriteLine();
    }
}