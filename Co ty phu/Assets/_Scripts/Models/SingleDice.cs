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

    public Vector3 PourDiceAgain()
    {
        
        float x = Random.Range(0, 360);
        float y = Random.Range(0, 360);
        float z = Random.Range(0, 360);
        Vector3 vt3 = new Vector3(x, y, z);
        Debug.Log("rotaion sau khi rab dom: " + vt3.x + " y: " + vt3.y + " z: " + vt3.z);
        return vt3;
    }


    public void PourDice(Vector3 vt3)
    {
        
        StartCoroutine(Play());
        Reset();
        transform.Rotate(vt3);
        Debug.Log("rotaion trc khi bay: " + vt3.x + " y: " + vt3.y + " z: " + vt3.z); 
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
    IEnumerator Play()
    {
        yield return new WaitWhile(() => !pour);
        yield return new WaitForSeconds(6f);
        rb.Sleep();
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
                // pour = false;
                
                // Debug.Log(Point);
            }
        }
    }
}
