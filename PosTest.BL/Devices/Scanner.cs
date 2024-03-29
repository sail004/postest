﻿using Pos.BL.Implementation.States;
using Pos.Entities.Devices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pos.BL.Implementation.Devices
{
    internal class Scanner:IDisposable
    {
        private SerialPort _port;
        public Action<string> BarcodeReceived { get; set; }
        private void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string received = _port.ReadLine();
            BarcodeReceived?.Invoke(received.TrimEnd(new char[] { '\r', '\n' }));
        }
        
        public Scanner(PosDevice posDevice)
        {
            if (posDevice.DeviceType == DeviceTypes.Scanner)
            {
                _port = new SerialPort("COM"+ posDevice.ComPort, 9600, Parity.None, 8, StopBits.One);
                _port.DataReceived += new SerialDataReceivedEventHandler(PortDataReceived);

                var task = Task.Run(() => _port.Open());
                if (!task.Wait(5000))
                {
                    // handle the timeout exception
                    throw new TimeoutException("Failed to open the port within 5 seconds.");
                }
            }
        }

        public void Dispose()
        {
            _port?.Close();
            _port?.Dispose();
        }
    }
}
