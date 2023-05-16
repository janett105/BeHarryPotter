using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackDefense;

public class MagicHandler : MonoBehaviour
{
    //음성인식+모션 둘 다 일치 시 마법
    //vlaues : Wit에서 음성 인식 성공 시, intent 값 받아옴
    public void MagicCheck(string[] values) 
    {
        //마법 : Incendio
        if (values[0] == "flame") { Flame(); };
        //마법 : Wingardium Leviosa
        if (values[0] == "levitate") { Levitate(); };
        //마법 : Repello
        if (values[0] == "defense") { Defense(); };
        //마법 : Immobulus
        if (values[0] == "freeze") { Freeze(); };
    }

    void Flame(){
        Debug.Log("This is flame");

        var at = new AttackedHandler();
        at.Attacked_Bhaptics(AttackedHandler.attackedDirection.Left);
        }
    void Levitate() {
        Debug.Log("This is levitate");
    }
    void Defense()
    {
        Debug.Log("This is defense");
    }
    void Freeze()
    {
        Debug.Log("This is freeze");
    }
}
