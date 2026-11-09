namespace DeliveryApp;


abstract class Transport
{
    public string Name;      
    public double MaxWeight; 
    public bool IsFree;       

    public Transport(string name, double maxWeight)
    {
        Name = name;
        MaxWeight = maxWeight;
        IsFree = true; 
    }

  
    public abstract double CalculateCost(Order order);

    public virtual bool CanTake(Order order)
    {
        return order.Weight <= MaxWeight;
    }

    public override string ToString()
    {
        string status = IsFree ? "вільний" : "зайнятий";
        return Name + " [" + status + ", макс. вага " + MaxWeight + " кг]";
    }
}
