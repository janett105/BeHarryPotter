using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defense : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)  
    {
        if (other.collider.gameObject.CompareTag("IceBall"))   //利 傍拜 规绢 己傍 矫 
        {
            //规绢 己傍 家府
        }
    }
}
