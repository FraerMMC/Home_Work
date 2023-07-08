
public abstract class Transport
{
    protected string _company;
    protected double _weight;
    protected string _mark;

    public Transport(string company, double weight, string mark)
    {
        _company = company;
        _weight = weight;
        _mark = mark;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine("Информация о транспорте:");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Кто собирал: {_company}");
        Console.WriteLine($"Вес транспорта: {_weight} тонн");
        Console.WriteLine($"Марка транспорта: {_mark}");
    }
}

public class Auto : Transport
{
    protected string _class;
    protected double _horsePower;
    protected double _fuelTankCapacity;

    public Auto(string company, double weight, string mark, double horsePower, double fuelTankCapacity) : base(company, weight, mark) 
    {
        
        _horsePower = horsePower;
        _fuelTankCapacity = fuelTankCapacity;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Мощность двигателя: {_horsePower} л/с");
        Console.WriteLine($"Ёмкость топливного бака: {_fuelTankCapacity} литров");
    }
}

public class Train : Transport
{
    protected double _trainCarNumber;
    protected string _route;

    public Train(string company, double weight, string mark, double trainCarNumber, string route) : base(company, weight, mark)
    {
        _trainCarNumber = trainCarNumber;
        _route = route;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Кол-во вагонов: {_trainCarNumber}");
        Console.WriteLine($"Маршрут поезда: {_route}");
    }
}

public class Airplane : Transport
{
    protected double _engineNumber;
    protected double _maxFlightRange;

    public Airplane(string company, double weight, string mark, double engineNumber, double maxFlightRange) : base(company, weight, mark)
    {
        _engineNumber = engineNumber;
        _maxFlightRange = maxFlightRange;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Кол-во двигателей: {_engineNumber}");
        Console.WriteLine($"Максимальная дальность полёта: {_maxFlightRange} км");
    }
}

public sealed class LightCar : Auto
{
    protected double _maxSpeed;
    protected string _class;
    

    public LightCar(string company, double weight, string mark, double horsePower,
        double fuelTankCapacity, double maxSpeed, string @class) : base(company, weight, mark, horsePower, fuelTankCapacity)
    {
        _maxSpeed = maxSpeed;
        _class = @class;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Макмимальная скорость: {_maxSpeed} км/ч");
        Console.WriteLine($"Класс автомобиля: {_class}");
    }
}

public sealed class Truck : Auto
{
    protected double _loadCapacity;

    public Truck(string company, double weight, string mark, double horsePower,
        double fuelTankCapacity, double loadCapacity) : base(company, weight, mark, horsePower, fuelTankCapacity)
    {
        _loadCapacity = loadCapacity;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Максимальная грузоподъёмность: {_loadCapacity} тонн");
    }
}

public sealed class Cargo : Airplane
{
    protected double _cargoCapacity;
    protected string _assignment;

    public Cargo(string company, double weight, string mark, double engineNumber,
        double maxFlightRange, double cargoCapacity, string assignment) : base(company, weight, mark, engineNumber, maxFlightRange)
    {
        _cargoCapacity = cargoCapacity;
        _assignment = assignment;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Вместимость грузового отсека: {_cargoCapacity} м^3");
        Console.WriteLine($"Назначение: {_assignment}");
    }
}

public sealed class PassengerPlane : Airplane
{
    protected double _passengersNumber;
    protected double _flightDuration;

    public PassengerPlane(string company, double weight, string mark, double engineNumber,
        double maxFlightRange, double passengersNumber, double flightDuration) : base(company, weight, mark, engineNumber, maxFlightRange)
    {
        _passengersNumber = passengersNumber;
        _flightDuration = flightDuration;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Мест в самолёте: {_passengersNumber}");
        Console.WriteLine($"Длительность полёта: {_flightDuration} ч");
    }
}

public class Goods
{
    public string _goodName;
    public int _goodCount;
    public int _goodCost;

    public Goods(string goodName, int goodCount, int goodCost)
    {
        _goodName = goodName;
        _goodCount = goodCount;
        _goodCost = goodCost;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Название товара: {_goodName}.|| Кол-во в автомате: {_goodCount}.|| Цена: {_goodCost}");
    }

}