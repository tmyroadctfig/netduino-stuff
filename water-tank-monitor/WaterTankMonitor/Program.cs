using System;
using System.Threading;
using System.Text;
using CW.NETMF.Hardware;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using CW.NETMF.Sensors;
using CW.NETMF;
using WaterTankMonitor.Sensors.Range;
using Toolbox.NETMF.NET;
using WaterTankMonitor.Sensors.OneWire;

namespace WaterTankMonitor
{
    public class Program
    {
        private static bool _writeToNetwork = false;
        private static ushort _networkPort = 12345;
        private static string _networkAddress = "192.168.15.3";

        public static void Main()
        {
            var rangeSensor = new HC_SR04(Pins.GPIO_PIN_D0, Pins.GPIO_PIN_D1);
            var dhtSensor = new Dht11Sensor(Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3, PullUpResistor.External);
            var oneWireBus = new OneWireBus(new OneWire(Pins.GPIO_PIN_D4));
            var tempSensor = (DS18B20)oneWireBus.FindTempSensors()[0];

            while (true)
            {
                StringBuilder status = new StringBuilder();

                var tankDepth = rangeSensor.Ping();
                
                if (tankDepth > 0)
                {
                    status.Append("depth.value " + tankDepth + "\n");
                }
                else
                {
                    status.Append("depth.value U\n");
                }
                
                if (dhtSensor.Read())
                {
                    status.Append("humidity.value " + dhtSensor.Humidity.ToString("F1") + "\n");
                    status.Append("dht-temp.value " + dhtSensor.Temperature.ToString("F1") + "\n");
                }
                else
                {
                    status.Append("humidity.value U\n");
                    status.Append("dht-temp.value U\n");
                }

                tempSensor.Read();
                status.Append("temp.value " + tempSensor.Temperature.ToString("F1") + "\n");

                WriteLine(status.ToString());

                Thread.Sleep(300 * 1000); // 5mins
            }
        }

        static void WriteLine(string line)
        {
            if (_writeToNetwork)
            {
                SimpleSocket socket = new IntegratedSocket(_networkAddress, _networkPort);

                try
                {
                    socket.Connect();
                    
                    socket.Send(line);
                    socket.Send("\r\n");
                }
                finally
                {
                    socket.Close();
                }
            }

            Debug.Print(line);
        }
    }
}
