//player collider 충돌 감지 후
//공격Type+충돌 방향+방어 성공 여부 따라 
//bhaptics(attacked) or sleeve(defense) signal
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    //void Start()
    //{
       
    //}
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)    //collisor 범위 안에 닿을 시, 공격체도 Collider component 필수
    {

        var AttackType = ChooseAttackType(other);
        

        //Vector2 direction = other.
        //    GetContact(0).normal;
        //If(direction.x == 1) print(“right”);
        //If(direction.x == -1) print(“left”);
        //If(direction.y == 1) print(“up”);
        //If(direction.y == -1) print(“down”);
    }
    private string ChooseAttackType(Collider other)
    {
        if (other.gameObject.CompareTag("FireBall"))    //불 공격이랑 충돌 시
        {
            return "FireBall";
        }
        else if (other.gameObject.CompareTag("IceBall"))    //얼음 공격이랑 충돌 시
        {
            return "IceBall";
        }
        else
        {
            return "None";
        }
    }
}
