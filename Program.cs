PassengerPlane passangerPlane = new PassengerPlane("Airbus", 30, "Airbus passangers", 8, 12000, 700, 8);
Cargo cargo = new Cargo("Airbus", 20, "Cargobob", 8, 20000, 500, "Военная промышленность");
LightCar lightCar = new LightCar("Audi", 2, "Audi", 250, 40, 357, "B");
Truck truck = new Truck("Volvo", 8, "Volvo truck", 400, 800, 30);
Train train = new Train("РЖД", 1104, "Иволга", 8, "Подольск - Челяба");

passangerPlane.ShowInfo();
Console.WriteLine();

cargo.ShowInfo();
Console.WriteLine();

lightCar.ShowInfo();
Console.WriteLine();

truck.ShowInfo();
Console.WriteLine();

train.ShowInfo();