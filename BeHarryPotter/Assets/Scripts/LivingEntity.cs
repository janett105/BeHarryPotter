using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour//, IDamageable 적용 예정
{
    public float startingHealth = 100f; //시작 체력
    public float health { get; protected set; } //현재 체력

    //생명체가 활성화될 떄 상태를 리셋
    protected virtual void OnEnable()
    {
        //체력을 시작 체력으로 초기화
        health = startingHealth;
    }


}