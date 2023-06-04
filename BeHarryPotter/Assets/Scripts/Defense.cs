//Defense collider 충돌 감지 후(방어 성공)
//AttackType 따라 
//arm sleeve signal
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;

public class Defense : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)    //collisor 범위 안에 닿을 시, 공격체도 Collider component 필수
    {
        var AttackType = ChooseAttackType(other);    //충돌 개체가 불 공격 or 얼음 공격
        var df = new ArmSleeveHandler();

    }
    private string ChooseAttackType(Collision other)
    {
        if (other.collider.gameObject.CompareTag("FireBall")) { return "FireBall"; }
        else if (other.collider.gameObject.CompareTag("IceBall")) { return "IceBall"; }
        else { return "None"; }
    }
}
