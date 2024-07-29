///Product Inventory Management

class Company : ICompany
{
    public List<(IProduct product, int quantity)> Products { get; set; }
    public List<IUser> Users { get; set; }

    public Company()
    {
        Products = new List<(IProduct product, int quantity)>();
        Users = new List<IUser>();
    }
    public void MakeOrder(List<(IProduct product, int quantity)> products, IUser user)
    {
        //find highest shippingCost from products and total price of products and check Products have enough quantity
        decimal highestShippingCost = 0;
        decimal totalPrice = 0;
        foreach (var item in products)
        {
            if (item.Item1.ShippingCost > highestShippingCost)
            {
                highestShippingCost = item.Item1.ShippingCost;
            }
            totalPrice += item.Item1.Price * item.Item2;
            var p = Products.FirstOrDefault(x => x.product.Name == item.product.Name);
            if (p.Equals(default((IProduct product, int quantity))))
            {
                //product not found
                return;
            }
            else if (p.quantity < item.quantity)
            {
                //not enough quantity
                return;
            }


        }
        //check if user has enough money
        if (user.Balance < totalPrice + highestShippingCost)
        {
            return;
        }
        user.Balance -= totalPrice + highestShippingCost;
        user.Orders.AddRange(products);
        //decrease Products counts
        foreach (var item in products)
        {
            var p = Products.FirstOrDefault(x => x.product.Name == item.product.Name);
            Products.Remove(p);            
            if (!p.Equals(default((IProduct product, int quantity))))
            {
                p.quantity -= item.quantity;
            }
            //update product in list
            Products.Add(p);
        }
    }

    public void AddProduct(IProduct product, int quantity)
    {
        //check if product exist
        var p = Products.FirstOrDefault(x => x.product.Name == product.Name);
        //increase quantity if product exist
        if (!p.Equals(default((IProduct product, int quantity))))
        {
            p.quantity += quantity;
        }
        else
        {
            Products.Add((product, quantity));
        }

    }

    public void AddUser(IUser user)
    {
        Users.Add(user);
    }
}

class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal ShippingCost { get; set; }

    public Product(int id, string name, decimal price, decimal shippingCost)
    {
        Id = id;
        Name = name;
        Price = price;
        ShippingCost = shippingCost;
    }
}

class User : IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public List<(IProduct product, int quantity)> Orders { get; set; }

    public User(int id, string name, decimal balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
        Orders = new List<(IProduct product, int quantity)>();
    }
}
