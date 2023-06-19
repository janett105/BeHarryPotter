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

        public void leftsignal()
        {
            Debug.Log("나지금 left보낸다?");
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
        public void rightsignal()
        {
            Debug.Log("나지금 right보낸다?");
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
        public void frontsignal()
        {
            Debug.Log("나지금 front보낸다?");
            serialController.SendSerialMessage("F");

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

            if (AttackType == "left")
            {
                Debug.Log("left 방어");
                leftsignal();

            }
            else if (AttackType == "right")
            {
                Debug.Log("right 방어");
                rightsignal();
            }
            else if (AttackType == "front")
            {
                Debug.Log("front 방어");
                frontsignal();
            }

        }
        private string ChooseAttackType(Collision other)
        {
            if (other.collider.gameObject.CompareTag("left")) { return "left"; }
            else if (other.collider.gameObject.CompareTag("right")) { return "right"; }
            else if (other.collider.gameObject.CompareTag("front")) { return "front"; }
            else { return "None"; }
        }
    }
}