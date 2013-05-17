using System;
using System.Threading;
using CW.NETMF.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using CW.NETMF.Sensors;
using CW.NETMF;
using WaterTankMonitor.Sensors.Range;
using WaterTankMonitor.Sensors.OneWire;

namespace WaterTankMonitor
{
    public class Program
    {
        public static void Main()
        {
            var rangeSensor = new HC_SR04(Pins.GPIO_PIN_D0, Pins.GPIO_PIN_D1);
            var dhtSensor = new Dht11Sensor(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, PullUpResistor.External);
            var oneWireBus = new OneWireBus(new OneWire(Pins.GPIO_PIN_D4));
            var tempSensor = (DS18B20)oneWireBus.FindTempSensors()[0];

            while (true)
            {
                var tankDepth = rangeSensor.Ping();
                
                if (tankDepth > 0)
                {
                    WriteLine("depth.value " + tankDepth);
                }
                else
                {
                    WriteLine("depth.value U");
                }
                
                if (dhtSensor.Read())
                {
                    WriteLine("humidity.value " + dhtSensor.Humidity.ToString("F1"));
                    WriteLine("dht-temp.value " + dhtSensor.Temperature.ToString("F1"));
                }
                else
                {
                    WriteLine("humidity.value U");
                    WriteLine("dht-temp.value U");
                }

                tempSensor.Read();
                WriteLine("temp.value " + tempSensor.Temperature.ToString("F1"));

                Thread.Sleep(300 * 1000); // 5mins
            }
        }

        static void WriteLine(string line)
        {
            Debug.Print(line);
        }
    }
}
