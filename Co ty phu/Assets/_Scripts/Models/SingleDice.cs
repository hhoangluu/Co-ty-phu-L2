using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SingleDice : MonoBehaviour
{
    Rigidbody rb;
    bool pour;
    bool hasLanded;
    Vector3 initPosition;
    MeshRenderer ms;

    public int Point { get; set; }
    public Rigidbody Rb { get => rb; set => rb = value; }
    public bool Pour { get => pour; set => pour = value; }
    public bool HasLanded { get => hasLanded; set => hasLanded = value; }
    public Vector3 InitPosition { get => initPosition; set => initPosition = value; }

    public DiceSide[] diceSides;

    // Start is called before the first frame update
    void Start()
    {
        ms = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
        hasLanded = false;

    }
    public bool IsPourDone()
    {
        if (rb.IsSleeping() && hasLanded && pour)
        {
            return true;
        }
     //   Debug.Log(name + " " + rb.IsSleeping() + " " + hasLanded + " " + pour);
        return false;
    }

    // Update is called once per frame
    public void CheckPoint()
    {
      //  Debug.Log(name + "  " + rb.IsSleeping());
        if (rb.IsSleeping() && !hasLanded && pour)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        //if (rb.velocity.x < 0.0005f && rb.velocity.y < 0.0005f && rb.velocity.z < 0.0005f && pour)
        //{
        //    if (Mathf.Abs(transform.rotation.x) < 0.001f)
        //    {
        //        rb.velocity = new Vector3(0, -5, 0);
        //       // rb.Sleep();
        //    }
        //    if (Mathf.Abs(transform.rotation.y) < 0.001f)
        //    {
        //        rb.velocity = new Vector3(0, -5, 0);
        //     //   rb.Sleep();
        //    }
        //    if (Mathf.Abs(transform.rotation.z) < 0.001f)
        //    {
        //        rb.velocity = new Vector3(0, -5, 0);
        //       // rb.Sleep();

        //    }
        //}
       


    }

    public void PourDiceAgain()
    {
        Reset();
        PourDice();
    }


    public void PourDice()
    {
        if (!pour && !hasLanded)
        {
            ms.enabled = true;
           // rb.WakeUp();
            pour = true;
            rb.useGravity = true;
            rb.AddTorque(100000, 100000, 100000);
            rb.velocity = new Vector3(-5, -10, 15);
        }

    }

    private void Reset()
    {
        transform.position = initPosition;
        pour = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
        Point = 0;
    }

    public void SideValueCheck()
    {
        foreach (DiceSide side in diceSides)
        {

            if (side.OnGound)
            {
                
                Point = side.SideValue;
               // Debug.Log(Point);
            }
        }
    }
}
