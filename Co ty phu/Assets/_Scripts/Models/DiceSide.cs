using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    private bool onGound = false;
    public int SideValue;

    public bool OnGound { get => onGound; set => onGound = value; }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ground")
        {
            onGound = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            onGound = false;
        }
    }

}
