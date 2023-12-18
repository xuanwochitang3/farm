using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool CanCreat { get; private set; } = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Crop")
        {
            CanCreat = false;
        }
        else
        {
            CanCreat = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Crop")
        {
            CanCreat = true;
        }    
    }

}
