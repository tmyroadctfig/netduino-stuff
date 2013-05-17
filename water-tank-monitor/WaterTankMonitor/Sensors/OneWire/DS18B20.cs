//---------------------------------------------------------------------------
//<copyright file="DS18B20.cs">
//
// Copyright 2010 Stanislav "CW" Simicek
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//</copyright>
//---------------------------------------------------------------------------
using System.Threading;
using System;
using Microsoft.SPOT;
namespace WaterTankMonitor.Sensors.OneWire
{
    /// <summary>
    /// DS18B20 Programmable Resolution 1-Wire Digital Thermometer
    /// </summary>
    public class DS18B20
    {
        public const byte FamilyCode = 0x28;

        // Commands
        public const byte ConvertT = 0x44;
        public const byte CopyScratchpad = 0x48;
        public const byte WriteScratchpad = 0x4E;
        public const byte ReadPowerSupply = 0xB4;
        public const byte RecallE2 = 0xB8;
        public const byte ReadScratchpad = 0xBE;

        // Helpers
        public static float GetTemperature(byte tempLo, byte tempHi)
        {
            return ((short)((tempHi << 8) | tempLo)) / 16F;
        }

        public DS18B20(CW.NETMF.Hardware.OneWire oneWire, byte[] deviceId)
        {
            OneWire = oneWire;
            _deviceId = deviceId;
        }

        /// <summary>
        /// The device ID.
        /// </summary>
        byte[] _deviceId;

        /// <summary>
        /// The one wire bus.
        /// </summary>
        public CW.NETMF.Hardware.OneWire OneWire { get; private set; }

        /// <summary>
        /// The last read temperature.
        /// </summary>
        public float Temperature { get; private set; }

        /// <summary>
        /// Reads the latest temperature from the device.
        /// </summary>
        public void Read()
        {
            if (_deviceId[0] == DS18B20.FamilyCode)
            {
                OneWire.Reset();
                OneWire.WriteByte(CW.NETMF.Hardware.OneWire.SkipRom); // Address all devices
                OneWire.WriteByte(DS18B20.ConvertT);
                Thread.Sleep(750);  // Wait Tconv (for default 12-bit resolution)

                // Write command and identifier at once
                var matchRom = new byte[9];
                Array.Copy(_deviceId, 0, matchRom, 1, 8);
                matchRom[0] = CW.NETMF.Hardware.OneWire.MatchRom;

                OneWire.Reset();
                OneWire.Write(matchRom);
                OneWire.WriteByte(DS18B20.ReadScratchpad);

                // Read just the temperature (2 bytes)
                var tempLo = OneWire.ReadByte();
                var tempHi = OneWire.ReadByte();
                Temperature = GetTemperature(tempLo, tempHi);
            }
        }
    }
}