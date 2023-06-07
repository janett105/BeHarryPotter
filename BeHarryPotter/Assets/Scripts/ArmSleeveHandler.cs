//sleeve�� on/off, cool/hot ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System;

namespace HapticsHandler
{
    public class ArmSleeveHandler : MonoBehaviour
    {
        private SerialPort serialPort = new SerialPort();

        public string defenseFasilSignal = "sucess";

        private void Start(){
            serialPort = new SerialPort("COM10", 9600);
            serialPort.Open();
        }

        private void FireSignal(){
            serialPort.WriteLine(defenseFailSignal);
        }
        private void IceSignal(){
            serialPort.WriteLine(defenseFailSignal);
        }

        private void Quit(){
            serialPort.Close();
        }

    }
}
