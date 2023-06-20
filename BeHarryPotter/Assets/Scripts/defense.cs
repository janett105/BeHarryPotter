using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    private AudioSource shieldmaker;

    private void Start()
    {
        shieldmaker = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("FireBall"))   //利 傍拜 规绢 己傍 矫 
        {
            //规绢 己傍 家府
            shieldmaker.Play();
        }

    }
}
