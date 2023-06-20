//player collider ï¿½æµ¹ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½(ï¿½ï¿½ï¿?ï¿½ï¿½ï¿½ï¿½)
//Bhaptics signal 
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using HapticsHandler;
using UnityEngine.Timeline;
using UnityEditor.UI;

public class Player : LivingEntity
{

    public AudioClip[] soundEffects;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        SignalToBhaptics(ChooseAttackDirection(other)); //Bhaptics signal
        audioSource.Play();
        
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

        //¿À: -0.67, 0, -0.74
        //¿Þ: 0.36, 0, -0.93
        //¾Õ: 0,0,-1

        if (direction.x == 0) { return "front"; }
        else if (direction.x < -0.3) { return "right"; }
        else if (direction.x > 0.3) { return "left"; }
        else if (direction.z == 1) { return "back"; }
        else { return "None"; };

        //if (LclD.x<=0 && LclD.y<=0 && LclD.z >= 0) { return "right"; }
        //else if (LclD.x >= 0 && LclD.y <= 0 && LclD.z >= 0) { return "front"; }
        //else if (LclD.x <= 0 && LclD.y <= 0 && LclD.z <= 0) { return "left"; }
        //else if (LclD.x >= 0 && LclD.y <= 0 && LclD.z <= 0) { return "back"; }
        //else { return "None"; }
    }
}
