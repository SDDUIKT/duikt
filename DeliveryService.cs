using System;
using System.Collections.Generic;

namespace DeliveryApp;

class DeliveryService
{
    private List<Transport> transports = new List<Transport>();
    private List<Order> activeOrders = new List<Order>();
    private List<Order> history = new List<Order>();

    public void AddTransport(Transport transport)
    {
        transports.Add(transport);
        Console.WriteLine("Додано транспорт: " + transport);
    }

    public Order CreateOrder(int number, string description, double weight, double distance)
    {
        Order order = new Order(number, description, weight, distance);
        Console.WriteLine("Створено: " + order);
        return order;
    }

    public void ShowCosts(Order order)
    {
        Console.WriteLine("Вартість для " + order + ":");
        bool found = false;
        foreach (Transport t in transports)
        {
            if (t.CanTake(order))
            {
                Console.WriteLine("  " + t.Name + ": " + t.CalculateCost(order) + " грн");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("  Жоден транспорт не може взяти це замовлення!");
        }
    }

    public bool Assign(Order order, Transport transport)
    {
        if (!transports.Contains(transport))
        {
            Console.WriteLine("Помилка: такого транспорту немає в службі.");
            return false;
        }
        if (activeOrders.Contains(order) || history.Contains(order))
        {
            Console.WriteLine("Помилка: замовлення №" + order.Number + " вже призначене або доставлене.");
            return false;
        }
        if (!transport.IsFree)
        {
            Console.WriteLine("Помилка: " + transport.Name + " зайнятий.");
            return false;
        }
        if (!transport.CanTake(order))
        {
            Console.WriteLine("Помилка: " + transport.Name + " не може взяти замовлення №" + order.Number + ".");
            return false;
        }

        order.AssignedTransport = transport;
        order.Cost = transport.CalculateCost(order);
        transport.IsFree = false;
        activeOrders.Add(order);
        Console.WriteLine("Замовлення №" + order.Number + " призначено на " + transport.Name
            + ". Вартість: " + order.Cost + " грн");
        return true;
    }

    public bool Deliver(Order order, IPayment payment)
    {
        if (!activeOrders.Contains(order))
        {
            Console.WriteLine("Помилка: замовлення №" + order.Number + " не є активним.");
            return false;
        }

        payment.Pay(order.Cost);
        order.PaymentName = payment.Name;

        order.AssignedTransport.IsFree = true; 
        activeOrders.Remove(order);            
        history.Add(order);                    
        Console.WriteLine("Замовлення №" + order.Number + " доставлено.");
        return true;
    }

    public void ShowActiveOrders()
    {
        Console.WriteLine("--- Активні замовлення ---");
        if (activeOrders.Count == 0)
        {
            Console.WriteLine("(порожньо)");
        }
        foreach (Order o in activeOrders)
        {
            Console.WriteLine(o + " | " + o.AssignedTransport.Name + " | " + o.Cost + " грн");
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("--- Історія доставок ---");
        if (history.Count == 0)
        {
            Console.WriteLine("(порожньо)");
        }
        foreach (Order o in history)
        {
            Console.WriteLine(o + " | " + o.AssignedTransport.Name + " | " + o.Cost + " грн | " + o.PaymentName);
        }
    }

    public void ShowTransports()
    {
        Console.WriteLine("--- Транспорт ---");
        foreach (Transport t in transports)
        {
            Console.WriteLine(t);
        }
    }
}
