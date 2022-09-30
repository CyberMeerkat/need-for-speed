using System;
using System.Linq;

class RemoteControlCar
{
    private int _batteryRemaining = 100;
    private int _distanceDriven = 0;
    private int _speed;
    private int _batteryDrainRate;
    public RemoteControlCar(int speed, int batteryDrainRate)
    {
        this._speed = speed;
        this._batteryDrainRate = batteryDrainRate;
    }

    public bool BatteryDrained() => _batteryRemaining < _batteryDrainRate;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            this._distanceDriven += _speed;
            this._batteryRemaining -= _batteryDrainRate;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _distance;
    public RaceTrack(int distance) => this._distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < this._distance)
        {
            car.Drive();
            if (car.BatteryDrained()) break;
        }
        return car.DistanceDriven() >= this._distance;
    }
}
