using System;

namespace DeliveryApp;

class CardPayment : IPayment
{
    public string Name { get { return "Картка"; } }

    public void Pay(double amount)
    {
        Console.WriteLine("Оплата карткою: " + amount + " грн");
    }
}

class CashPayment : IPayment
{
    public string Name { get { return "Готівка"; } }

    public void Pay(double amount)
    {
        Console.WriteLine("Оплата готівкою: " + amount + " грн");
    }
}
