//음성인식  일치 시 마법 activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;
using UnityEditor;

public class MagicHandler : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject icePrefab;
    public GameObject defensePrefab;
    public Transform magicPos;

    private float speed = 5f;

    public void MagicCheck(string[] values)    //values : Wit에서 음성 인식 성공 시, intent 값 받아옴
    {
        //마법 : Incendio
        if (values[0] == "flame") { Flame(); };
        //마법 : Protego
        if (values[0] == "defense") { Defense(); };
    }
    
    void Flame()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(firePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("This is flame");
    }
    void Defense()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(defensePrefab, new Vector3(0.74f, 7.13f, -0.67f), Quaternion.Euler(new Vector3(90,0,0)));
        Debug.Log("This is defense");
        Destroy(magic, 5f);
    }
}
