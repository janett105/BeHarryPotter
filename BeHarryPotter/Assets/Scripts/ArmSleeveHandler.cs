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

        public string defenseFasilSignal = "Success";

        private void Start(){
            serialPort = new SerialPort("COM10", 9600);
            serialPort.Open();
        }
        private void Update(){
            //if //(방어 실패시){
            //    serialPort.WriteLine(defenseFailSignal);
            //}
        }
        private void Quit(){
            serialPort.Close();
        }

    }
}