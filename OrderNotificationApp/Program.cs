using System;


public class Order
{
    public int Id { get; set; }
    public double Price { get; set; }
}


public static class OrderExt
{
    public static string Print(this Order o)
    {
        return "Order #" + o.Id + " price = " + o.Price;
    }
}

public class OrderService
{
    public event Action<Order> OrderDone;

    public void MakeOrder(Order ord, Func<Order, bool> check)
    {
        if (ord == null)
        {
            Console.WriteLine("order is null !");
            return;
        }

        Console.WriteLine("placing order...");

        if (check(ord))
        {
            Console.WriteLine("done ");
            OrderDone?.Invoke(ord);
        }
        else
        {
            Console.WriteLine("rejected");
        }
    }
}

public class EmailService
{
    public void Send(Order o)
    {
        Console.WriteLine("email => " + o.Print());
    }
}

public class SmsService
{
    public void Send(Order o)
    {
        Console.WriteLine("sms => " + o.Print());
    }
}

public class App
{
    public void Run()
    {
        var service = Setup();

        var order = new Order { Id = 1, Price = 300 };

        Start(service, order);
    }

    private OrderService Setup()
    {
        var service = new OrderService();

        var email = new EmailService();
        var sms = new SmsService();

        service.OrderDone += email.Send;
        service.OrderDone += sms.Send;

        service.OrderDone += o => Console.WriteLine("log -> " + o.Print());

        return service;
    }

    private void Start(OrderService service, Order order)
    {
        service.MakeOrder(order, o => o.Price > 100);
    }
}

class Program
{
    static void Main()
    {
        new App().Run();
    }
}


