//player collider 충돌 감지 후(방어 실패)
//AttackDirection 따라 
//bhaptics(attacked) signal
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using HapticsHandler;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)    //collisor 범위 안에 닿을 시, 공격체도 Collider component 필수
    {
        var AttackDirection = ChooseAttackDirection(other);    //충돌 방향
        var at = new BHapticsHandler();

        if (AttackDirection == "right")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Right);
        }
        else if(AttackDirection == "left")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Left);
        }
        else if (AttackDirection == "front")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Front);
        }
        else if (AttackDirection == "back")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Back);
        }
    }

    private string ChooseAttackDirection(Collision other)
    {
        Vector3 direction = other.GetContact(0).normal;

        if (direction.x == 1) { return  "left"; }
        else if (direction.x == -1) { return "right"; }
        else if (direction.z == 1) { return "back"; }
        else if (direction.z == -1) { return "front"; }
        else { return "None"; };
    }
}
