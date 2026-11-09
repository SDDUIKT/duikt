using System;

namespace DeliveryApp;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DeliveryService service = new DeliveryService();

        Console.WriteLine("===== 1. Створення транспорту і замовлень =====");
        Bike bike = new Bike("Велосипед");
        Car car = new Car("Автомобіль");
        Truck truck = new Truck("Вантажівка");
        service.AddTransport(bike);
        service.AddTransport(car);
        service.AddTransport(truck);

        Order o1 = service.CreateOrder(1, "Документи", 1, 5);       
        Order o2 = service.CreateOrder(2, "Піца", 2, 15);          
        Order o3 = service.CreateOrder(3, "Холодильник", 40, 8);     
        Order o4 = service.CreateOrder(4, "Меблі", 300, 20);       
        Order o5 = service.CreateOrder(5, "Бетон", 5000, 10);        
        Order o6 = service.CreateOrder(6, "Книги", 3, 4);          

        Console.WriteLine();
        Console.WriteLine("===== 2. Вартість доставки =====");
        service.ShowCosts(o1);
        service.ShowCosts(o2);
        service.ShowCosts(o3);
        service.ShowCosts(o4);
        service.ShowCosts(o5);

        Console.WriteLine();
        Console.WriteLine("===== 3. Призначення замовлень =====");
        service.Assign(o1, bike);    
        service.Assign(o6, bike);   
        service.Assign(o2, bike);    
        service.Assign(o3, car);     
        service.Assign(o4, car);   
        service.Assign(o4, truck);  
        service.Assign(o5, truck);  
        service.Assign(o1, car);    
        service.ShowTransports();

        Console.WriteLine();
        Console.WriteLine("===== 5. Активні замовлення і історія (до доставки) =====");
        service.ShowActiveOrders();
        service.ShowHistory();

        Console.WriteLine();
        Console.WriteLine("===== 4. Доставка з оплатою =====");
        service.Deliver(o1, new CardPayment());  
        service.Deliver(o3, new CashPayment());   
        service.Deliver(o1, new CashPayment());   
        service.Deliver(o2, new CardPayment()); 
        service.ShowTransports();

        Console.WriteLine();
        Console.WriteLine("===== Транспорт звільнився - призначаємо ще раз =====");
        service.Assign(o2, bike);               
        service.Assign(o5, car);                
        service.Assign(o6, bike);               
        service.Deliver(o6, new CashPayment());

        Console.WriteLine();
        Console.WriteLine("===== 5. Активні замовлення і історія (після доставки) =====");
        service.ShowActiveOrders();
        service.ShowHistory();
    }
}
