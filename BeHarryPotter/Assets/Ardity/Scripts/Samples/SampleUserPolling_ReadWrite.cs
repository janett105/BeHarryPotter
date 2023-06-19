//player collider 충돌 감지 후(방어 실패)
//Bhaptics signal + ArmSleeve signal(Sample User Polling_readwrite script)

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
        private void OnCollisionEnter(Collision other)
        {
            SignalToSleeve(ChooseAttackDirection(other));
        }

        private void SignalToSleeve(string AttackDirection)
        {
            if (AttackDirection == "front")
            {
                frontsignal();
            }
            else if(AttackDirection == "left")
            {
                leftsignal();
            }
            else if (AttackDirection == "right")
            {
                rightsignal();
            }

        }

        private string ChooseAttackDirection(Collision other)
        {
            Vector3 direction = other.GetContact(0).normal;

            Debug.Log(direction);

            if (0.5 <= direction.x || direction.x <= 1.5) { return "left"; }
            else if (-1.5 <= direction.x || direction.x <= -0.5) { return "right"; }
            else if (direction.z == 1) { return "back"; }
            else if (direction.z == -1) { return "front"; }
            else { return "None"; };
        }
    }
}