using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    bool pour;
    bool hasLanded;
    private Vector3 initPosition;

    public int Point { get; set; }

    public DiceSide[] diceSides;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
        hasLanded = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PourDice();
         
        }

        if (rb.IsSleeping() && !hasLanded && pour)
        {
           
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        else if (rb.IsSleeping() && hasLanded && Point == 0)
        {
            PourDiceAgain();
        }
    }

    private void PourDiceAgain()
    {
        Reset();
        pour = true;
        rb.useGravity = true;
        rb.AddTorque(1000, 1000, 1000); 
    }


    private void PourDice()
    {
        if (!pour && !hasLanded)
        {
            pour = true;
            rb.useGravity = true;
            rb.AddTorque(1000, 1000, 1000);
        }
        else if ( pour && hasLanded)
        {
           
            PourDiceAgain();

        }
        
    }

    private void Reset()
    {
        transform.position = initPosition;
        pour = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    private void SideValueCheck()
    {
        Point = 0;
        
        foreach (DiceSide side in diceSides)
        {
          
            if (side.OnGound)
            {
                Point = side.SideValue;
                Debug.Log(Point + "diem");
            }
        }
    }
}
