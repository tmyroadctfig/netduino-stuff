//---------------------------------------------------------------------------
//<copyright file="Program.cs">
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
using System;
using System.Collections;
using Microsoft.SPOT;
using CW.NETMF.Hardware;
using System.Threading;

namespace WaterTankMonitor.Sensors.OneWire
{
    public class OneWireBus
    {
        public OneWireBus(CW.NETMF.Hardware.OneWire oneWire)
        {
            OneWire = oneWire;
        }

        public CW.NETMF.Hardware.OneWire OneWire { get; private set; }

        /// <summary>
        /// Finds all the temperature sensors on the bus.
        /// </summary>
        /// <returns>The list of temperature sensors.</returns>
        public ArrayList FindTempSensors()
        {
            //---------------------------------------------------------------------
            // Reset/Presence
            if (OneWire.Reset())
            {
                Debug.Print("1-Wire device present");
            }
            else
            {
                Debug.Print("1-Wire device NOT present");
            }

            var rom = new byte[8];

            //---------------------------------------------------------------------
            // Read ROM
            if (OneWire.Reset())
            {
                OneWire.WriteByte(CW.NETMF.Hardware.OneWire.ReadRom);
                OneWire.Read(rom);
                if (CW.NETMF.Hardware.OneWire.ComputeCRC(rom, count: 7) != rom[7])
                {
                    // Failed CRC indicates presence of multiple slave devices on the bus
                    Debug.Print("Multiple devices present");
                }
                else
                {
                    Debug.Print("Single device present");
                }
            }

            var sensors = new ArrayList();

            //---------------------------------------------------------------------
            // Search ROM: First & Next (Enumerate all devices)
            var deviation = 0;  // Search result
            do
            {
                if ((deviation = OneWire.Search(rom, deviation)) == -1)
                    break;
                if (CW.NETMF.Hardware.OneWire.ComputeCRC(rom, count: 7) == rom[7])
                {
                    Debug.Print(OneWireExtensions.BytesToHexString(rom));

                    if (rom[0] == DS18B20.FamilyCode)
                    {
                        sensors.Add(new DS18B20(OneWire, rom));
                        rom = new byte[8];
                    }
                }
            }
            while (deviation > 0);

            return sensors;
        }
    }
}
