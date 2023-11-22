using System;

public abstract class Car
{
    public abstract void Info();
    public void Interact(Engine engine)
    {
        Info();
        Console.WriteLine("Set Engine: ");
        engine.GetPower();
    }
}

public abstract class Engine
{
    public virtual void GetPower()
    {
    }
}

public class Ford : Car
{
    public override void Info()
    {
        Console.WriteLine("Ford");
    }
}

public class Toyota : Car
{
    public override void Info()
    {
        Console.WriteLine("Toyota");
    }
}

public class Mercedes : Car
{
    public override void Info()
    {
        Console.WriteLine("Mercedes");
    }
}

public class FordEngine : Engine
{
    public override void GetPower()
    {
        Console.WriteLine("Ford Engine");
    }
}

public class ToyotaEngine : Engine
{
    public override void GetPower()
    {
        Console.WriteLine("Toyota Engine");
    }
}

public class MercedesEngine : Engine
{
    public override void GetPower()
    {
        Console.WriteLine("Mercedes Engine");
    }
}

public interface ICarFactory
{
    Car CreateCar();
    Engine CreateEngine();
}

public class FordFactory : ICarFactory
{
    public Car CreateCar()
    {
        return new Ford();
    }

    public Engine CreateEngine()
    {
        return new FordEngine();
    }
}

public class ToyotaFactory : ICarFactory
{
    public Car CreateCar()
    {
        return new Toyota();
    }

    public Engine CreateEngine()
    {
        return new ToyotaEngine();
    }
}

public class MercedesFactory : ICarFactory
{
    public Car CreateCar()
    {
        return new Mercedes();
    }

    public Engine CreateEngine()
    {
        return new MercedesEngine();
    }
}

public class ClientFactory
{
    private Car car;
    private Engine engine;

    public ClientFactory(ICarFactory factory)
    {
        car = factory.CreateCar();
        engine = factory.CreateEngine();
    }

    public void Run()
    {
        car.Info();
        car.Interact(engine);
    }
}

class EngineStartupSystem
{
    public void BeginStartup()
    {
        Console.WriteLine("EngineStartupSystem: Starting Engine");
    }
}

class AccelerationSystem
{
    public void ApplyAcceleration()
    {
        Console.WriteLine("AccelerationSystem: Applying Acceleration");
    }
}

class BrakeSystem
{
    public void ApplyBrakes()
    {
        Console.WriteLine("BrakeSystem: Applying Brakes");
    }
}

class DashboardSystem
{
    public void DisplayDashboardInfo()
    {
        Console.WriteLine("DashboardSystem: Displaying Dashboard Information");
    }
}

class CarControlFacade
{
    private EngineStartupSystem engineStartup;
    private AccelerationSystem acceleration;
    private BrakeSystem brakes;
    private DashboardSystem dashboard;

    public CarControlFacade()
    {
        engineStartup = new EngineStartupSystem();
        acceleration = new AccelerationSystem();
        brakes = new BrakeSystem();
        dashboard = new DashboardSystem();
    }

    public void StartCar()
    {
        Console.WriteLine("\nStartCar() ---- ");
        engineStartup.BeginStartup();
        dashboard.DisplayDashboardInfo();
    }

    public void DriveCar()
    {
        Console.WriteLine("\nDriveCar() ---- ");
        acceleration.ApplyAcceleration();
    }

    public void StopCar()
    {
        Console.WriteLine("\nStopCar() ---- ");
        brakes.ApplyBrakes();
    }
}


class AbstractFactoryApp
{
    static void Main(string[] args)
    {
        
        ICarFactory carFactory = new ToyotaFactory();
        var client1 = new ClientFactory(carFactory);
        client1.Run();

        carFactory = new FordFactory();
        var client2 = new ClientFactory(carFactory);
        client2.Run();

        carFactory = new MercedesFactory();
        var client3 = new ClientFactory(carFactory);
        client3.Run();

       
        CarControlFacade carControl = new CarControlFacade();
        carControl.StartCar();
        carControl.DriveCar();
        carControl.StopCar();
    }
}
