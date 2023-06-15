using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WitActivation : MonoBehaviour
{
    [SerializeField] private Wit wit;

    private void Update()
    {
        //OVRInput.Update(){

        //}
        if (!wit) wit = GetComponent<Wit>();

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)>0.5f)    //1. trigger
        {
            Debug.Log("trigger, start");
            wit.ActivateImmediately();
        }
        else
        {
            //if(wit.)
            wit.Deactivate();
        }

        if (OVRInput.GetDown(OVRInput.Button.One))    //2. A button ´©¸£¸é 
        {
            Debug.Log("button, start");
            wit.ActivateImmediately();
        }
        else if(OVRInput.GetUp(OVRInput.Button.One))    //2. A button ¶¼¸é
        {
            //if (wit.)
                wit.Deactivate();
        }

        if (Input.GetKeyDown(KeyCode.Space)) //test. space bar
        {
            Debug.Log("spacebar, start");
            wit.ActivateImmediately();
        }
        else
        {
            //if (wit.)
                wit.Deactivate();
        }
    }
}
