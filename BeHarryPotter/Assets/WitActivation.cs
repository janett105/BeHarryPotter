using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitActivation : MonoBehaviour
{
    [SerializeField] private Wit wit;

    private void Update()
    {
        if (!wit) wit = GetComponent<Wit>();
        if (Input.GetKeyDown(KeyCode.Space))    //space bar누르면,
        {
            wit.Activate();
        }
    }

    public void TriggerPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //space bar누르면,
        {
            wit.Activate();
        }
    }
}
