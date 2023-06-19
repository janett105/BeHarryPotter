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

        OVRInput.Update();

        if (OVRInput.Get(OVRInput.RawButton.A))    //2. A button ´©¸£¸é 
        {
            wit.Activate();
        }
    }
}
