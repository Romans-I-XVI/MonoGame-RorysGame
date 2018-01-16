using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace RorysGame
{
    public static class AccelerometerSensor
    {
        static Accelerometer _accelSensor;
        public static Vector2 CurrentAcceleration;

        static public void Start()
        {
            if (_accelSensor == null)
            {
                _accelSensor = new Accelerometer();

                _accelSensor.CurrentValueChanged += _accelSensor_CurrentValueChanged;

                _accelSensor.Start();

            }
        }

        static void _accelSensor_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            CurrentAcceleration.Y = e.SensorReading.Acceleration.Y;
            CurrentAcceleration.X = -e.SensorReading.Acceleration.X;
        }
    }
}