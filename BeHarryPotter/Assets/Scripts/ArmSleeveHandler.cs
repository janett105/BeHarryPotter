//sleeve�� on/off, cool/hot ����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

namespace HapticsHandler
{
    public class ArmSleeveHandler : MonoBehaviour
    {
        private SerialPort serialPort;

        private void Start(){
            serialPort = new SerialPort("COM10", 9600);
            serialPort.Open();
        }
        public void firesignal (){
            serialPort.Write("f");
        }
        public void icesignal(){
            serialPort.Write("i");
        }
        private void Quit(){
            serialPort.Close();
        }

    }
}