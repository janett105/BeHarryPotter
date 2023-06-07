//Bhaptics에 상/하/좌/우 전달
using Bhaptics.SDK2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Bhaptics.SDK2.BhapticsLibrary;

namespace HapticsHandler
{
    public class BHapticsHandler : MonoBehaviour
    {
        public enum attackedDirection { Left, Right, Front, Back };
        public void Attacked_Bhaptics(attackedDirection direction)
        {
            bool isAutoRunPlayer = false;

            if (BhapticsLibrary.IsBhapticsAvailable(isAutoRunPlayer))
            {
                if (direction == attackedDirection.Left) {
                    Debug.Log("bhaptics_left");
                    BhapticsLibrary.Play("attacked_left"); }
                else if (direction == attackedDirection.Right) {
                    Debug.Log("bhaptics_right");
                    BhapticsLibrary.Play("attacked_right"); }
                else if (direction == attackedDirection.Front) {
                    Debug.Log("bhaptics_front");
                    BhapticsLibrary.Play("attacked_front"); }
                else if (direction == attackedDirection.Back) {
                    Debug.Log("bhaptics_back");
                    BhapticsLibrary.Play("attacked_back"); }
            }
        }
    }
}