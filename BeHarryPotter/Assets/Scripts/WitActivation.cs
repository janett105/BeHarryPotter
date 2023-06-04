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
        if (!wit) wit = GetComponent<Wit>();
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger)>0.7f)    //controller button ´©¸£¸é,
        {
            wit.Activate();
        }
    }
}
