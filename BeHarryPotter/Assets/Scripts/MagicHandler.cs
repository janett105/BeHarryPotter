//�����ν�  ��ġ �� ���� activate
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


    public void MagicCheck(string[] values)    //values : Wit���� ���� �ν� ���� ��, intent �� �޾ƿ�
    {
        //���� : Incendio
        if (values[0] == "flame") { Flame(); };
        //���� : Protego
        if (values[0] == "defense") { Defense(); };
    }
    
    void Flame()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(icePrefab, magicPos.transform.position, magicPos.transform.rotation);
        Debug.Log("���� ����");
        playsoundeffect(1);
    }
    void Defense()
    {
        OVRInput.SetControllerVibration(1f, 2f, OVRInput.Controller.RHand);
        GameObject magic = Instantiate(defensePrefab, new Vector3(0.74f, 7.13f, -0.67f), Quaternion.Euler(new Vector3(0,0,0)));
        Debug.Log("This is defense");
        Destroy(magic, 5f);
    }
}
