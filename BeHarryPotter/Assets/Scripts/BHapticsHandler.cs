//Bhapticsø° ªÛ/«œ/¡¬/øÏ ¿¸¥ﬁ
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
                    BhapticsLibrary.Play("attacked_left");
                    Debug.Log("∫Ò«›∆ΩΩ∫ Left");
                }
                else if (direction == attackedDirection.Right) {
                    BhapticsLibrary.Play("attacked_right");
                    Debug.Log("∫Ò«›∆ΩΩ∫ Right");
                }
                else if (direction == attackedDirection.Front) {
                    BhapticsLibrary.Play("attacked_front");
                    Debug.Log("∫Ò«›∆ΩΩ∫ Front");
                }
                else if (direction == attackedDirection.Back) {
                    BhapticsLibrary.Play("attacked_back");
                    Debug.Log("∫Ò«›∆ΩΩ∫ Back");
                }
            }
        }
    }
}