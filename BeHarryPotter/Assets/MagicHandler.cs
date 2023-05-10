using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Flame(){ }
    void Levitate() { }
}
