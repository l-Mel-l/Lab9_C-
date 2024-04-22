public class Car{
    public string Model { get; private set; }

    public Car(string model){
        Model = model;
    }

    // Метод для демонстрации, что автомобиль помыт.
    public void Clean(){
        Console.WriteLine($"{Model} был помыт.");
    }
}
public class Garage{
    private List<Car> cars = new List<Car>();

    public delegate void CarWashDelegate(Car car);

    public void AddCar(Car car){
        cars.Add(car);
    }

    // Данный метод принимает делегат, который будет применён к каждому автомобилю в гараже.
    public void ProcessCars(CarWashDelegate washDelegate){
        foreach (var car in cars){
            washDelegate(car);  // Вызов делегата для каждого автомобиля
        }
    }
}
public class Washer{
    public void Wash(Car car){
        car.Clean();
    }
}
class Program{
    static void Main(){
        Garage garage = new Garage();
        Washer washer = new Washer();

        // Добавляем автомобили в гараж
        garage.AddCar(new Car("Toyota Camry"));
        garage.AddCar(new Car("Ford Mustang"));
        garage.AddCar(new Car("Tesla Model S"));

        // Создаем делегат, указывающий на метод Wash объекта washer
        Garage.CarWashDelegate washDelegate = washer.Wash;

        // Делегируем мойку всех автомобилей мойке
        garage.ProcessCars(washDelegate);
    }
}