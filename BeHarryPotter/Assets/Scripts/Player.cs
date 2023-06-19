//player collider 충돌 감지 후(방어 실패)
//Bhaptics signal + ArmSleeve signal(Sample User Polling_readwrite script)
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using HapticsHandler;
using UnityEngine.Timeline;



public class Player : MonoBehaviour
{
    public AudioClip[] soundEffects;  // 다른 효과음을 담을 배열

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 플레이어의 행동에 따라 다른 효과음을 재생하는 함수
    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            audioSource.clip = soundEffects[index];
            audioSource.Play();
        }
    }


    private void OnCollisionEnter(Collision other)    //collisor 범위 안에 닿을 시, 공격체도 Collider component 필수
    {
        SignalToBhaptics(ChooseAttackDirection(other)); //Bhaptics signal
    }

    private void SignalToBhaptics(string AttackDirection)
    {
        var at = new BHapticsHandler();

        if (AttackDirection == "right")
        {
            at.Attacked_Bhaptics(BHapticsHandler.attackedDirection.Right);
        }
        else if (AttackDirection == "left")
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

        Debug.Log(direction);

        if (0.5<=direction.x || direction.x <= 1.5) { return  "left"; }
        else if (-1.5 <= direction.x || direction.x <= -0.5) { return "right"; }
        else if (direction.z == 1) { return "back"; }
        else if (direction.z == -1) { return "front"; }
        else { return "None"; };
    }
}
