namespace DeliveryApp;

class Order
{
    public int Number;          
    public string Description;  
    public double Weight;      
    public double Distance;     

    public Transport AssignedTransport; 
    public double Cost;                 
    public string PaymentName;         

    public Order(int number, string description, double weight, double distance)
    {
        Number = number;
        Description = description;
        Weight = weight;
        Distance = distance;
    }

    public override string ToString()
    {
        return "Замовлення №" + Number + " (" + Description + ", " + Weight + " кг, " + Distance + " км)";
    }
}
