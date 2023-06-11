//음성인식  일치 시 마법 activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;

public class MagicHandler : Magic
{
    public GameObject magicPrefab;

    public void MagicCheck(string[] values)    //vlaues : Wit에서 음성 인식 성공 시, intent 값 받아옴
    {
        //마법 : Incendio
        if (values[0] == "flame") { Flame(); };
        //마법 : Protego
        if (values[0] == "defense") { Defense(); };
        //마법 : Immobulus
        if (values[0] == "freeze") { Freeze(); };
    }

    void Flame(){
 //       GameObject magic = Instantiate(magicPrefab, magicPos.position, magicPos.rotation);
        Debug.Log("This is flame");
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
