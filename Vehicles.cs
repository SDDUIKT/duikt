namespace DeliveryApp;


class Bike : Transport
{
    public Bike(string name) : base(name, 5) { }

    public override double CalculateCost(Order order)
    {
        return 20 + 5 * order.Distance;
    }

 
    public override bool CanTake(Order order)
    {
        return order.Weight <= MaxWeight && order.Distance <= 10;
    }
}


class Car : Transport
{
    public Car(string name) : base(name, 50) { }

    public override double CalculateCost(Order order)
    {
        return 50 + 8 * order.Distance + 1 * order.Weight;
    }
}

class Truck : Transport
{
    public Truck(string name) : base(name, 1000) { }

    public override double CalculateCost(Order order)
    {
        return 200 + 15 * order.Distance + 0.5 * order.Weight;
    }
}
