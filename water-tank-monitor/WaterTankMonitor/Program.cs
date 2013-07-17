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
using WaterTankMonitor.Util;
using WaterTankMonitor.Sensors.OneWire;

namespace WaterTankMonitor
{
    public class Program
    {
        private static bool _writeToNetwork = true;
        private static bool _useDhcp = true;
        private static ushort _networkPort = 12345;
        private static string _networkAddress = "192.168.15.3";

        public static void Main()
        {
            if (_writeToNetwork && _useDhcp)
            {
                Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].EnableDhcp();
            }

            Debug.Print("IP Address:" + Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPAddress);

            var tankDepthAverage = new Int32RollingAverage(50);
            var dhtHumidityAverage = new FloatRollingAverage(50);
            var dhtTempAverage = new FloatRollingAverage(50);
            var oneWireTempAverage = new FloatRollingAverage(50);

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
                    tankDepthAverage.AddValue((int) tankDepth);

                    status.Append("depth.value " + tankDepthAverage.Average() + "\n");
                }
                else
                {
                    status.Append("depth.value U\n");
                }

                if (dhtSensor.Read())
                {
                    dhtHumidityAverage.AddValue(dhtSensor.Humidity);
                    dhtTempAverage.AddValue(dhtSensor.Temperature);

                    status.Append("humidity.value " + dhtHumidityAverage.Average().ToString("F1") + "\n");
                    status.Append("dht-temp.value " + dhtTempAverage.Average().ToString("F1") + "\n");
                }
                else
                {
                    status.Append("humidity.value U\n");
                    status.Append("dht-temp.value U\n");
                }

                tempSensor.Read();
                oneWireTempAverage.AddValue(tempSensor.Temperature);
                status.Append("temp.value " + oneWireTempAverage.Average().ToString("F1") + "\n");

                WriteLine(status.ToString());

                //Thread.Sleep(300 * 1000); // 5mins
                Thread.Sleep(10000); // 10s
            }
        }

        static void WriteLine(string line)
        {
            if (_writeToNetwork)
            {
                try
                {
                    SimpleSocket socket = new IntegratedSocket(_networkAddress, _networkPort);

                    try
                    {
                        Debug.Print("Connecting to: " + _networkAddress);
                        socket.Connect();

                        socket.Send(line);
                        socket.Send("\r\n");
                    }
                    finally
                    {
                        socket.Close();
                    }
                }
                catch (Exception e)
                {
                    Debug.Print("Error writing to socket: " + e.Message);
                }
            }

            Debug.Print(line);
        }
    }
}
