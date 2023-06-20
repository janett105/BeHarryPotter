//음성인식  일치 시 마법 activate
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HapticsHandler;
using UnityEditor;

public class MagicHandler : MonoBehaviour
{
    public GameObject icePrefab;
    public GameObject defensePrefab;
    public Transform magicPos;

    public AudioClip[] audiosource;
    public AudioSource audioSource;
    //public AudioClip attackspell;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
    }

    public void playsoundeffect(int index)
    {
        if(index >= 0 && index < audiosource.Length)
        {
            audioSource.clip = audiosource[index];
            audioSource.Play();
        }
    }


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
        GameObject magic = Instantiate(icePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("얼음 공격");
        playsoundeffect(0);
    }
    void Defense()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(defensePrefab, new Vector3(0.74f, 8f, 7.7f), Quaternion.Euler(new Vector3(90,0,0)));
        Debug.Log("방어막 생성");
        playsoundeffect(0); 
        Destroy(magic, 5f);
    }
}
