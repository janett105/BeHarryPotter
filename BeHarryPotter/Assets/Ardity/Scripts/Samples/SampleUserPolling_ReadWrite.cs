/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

namespace HapticsHandler
{
    public class SampleUserPolling_ReadWrite : MonoBehaviour
    {
        public SerialController serialController;

        void Start()
        {
            serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        }

        public void firesignal()
        {
            //Debug.Log("나지금 fire보낸다?");
            serialController.SendSerialMessage("A");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            // Check if the message is plain data or a connect/disconnect event.
            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }
        public void icesignal()
        {
            //Debug.Log("나지금 ice보낸다?");
            serialController.SendSerialMessage("Z");

            string message = serialController.ReadSerialMessage();

            if (message == null)
                return;

            // Check if the message is plain data or a connect/disconnect event.
            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("Connection established");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("Connection attempt failed or disconnection detected");
            else
                Debug.Log("Message arrived: " + message);
        }


        //방어막 object script(Defense)
        private void OnCollisionEnter(Collision other)    //방어막 object : collider, 이 script있으면 됨 
        {
            var AttackType = ChooseAttackType(other);

            if (AttackType == "FireBall")
            {
                //Debug.Log("파이어볼 방어");
                firesignal();

            }
            else if (AttackType == "IceBall")
            {
                //Debug.Log("아이스볼 방어");
                icesignal();
            }
        }
        private string ChooseAttackType(Collision other)
        {
            if (other.collider.gameObject.CompareTag("FireBall")) { return "FireBall"; }
            else if (other.collider.gameObject.CompareTag("IceBall")) { return "IceBall"; }
            else { return "None"; }
        }


        private void Update()
        {

            OVRInput.Update();

            //if (OVRInput.Get(OVRInput.RawButton.B))    //2. A button 누르면 
            //{
            //    firesignal();
            //    Debug.Log("dsbdusfgsgbfsgbfubsuf s");
            //}
            //else if (OVRInput.GetUp(OVRInput.Button.One))    //2. A button 떼면
            //{
            //    Debug.Log("button, end");
            //    //wit.Deactivate();
            //}
            if (OVRInput.Get(OVRInput.RawButton.A))    //2. A button 누르면 
            {
                icesignal();
            }
        }

    }
}