using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    public GameObject plotPrefap;
    public GameObject bigPlotPrefap;
   

    public Vector3 basePosition;
    private Plot[] _plots; 
    public Plot[] Plots
    {
        get { return _plots; }
        
    }
    [ContextMenu("check")]
    public void check()
    {
        Start();
    }
    public void Init()
    {
        _plots = new Plot[32];
        for (int i =0; i< 32; i++)
        {
            
            GameObject c = null;
            if (i % 8 == 0) {
                c = GameObject.Instantiate(bigPlotPrefap, CanculatePosition(i), Quaternion.identity) as GameObject;
            }
            else
            {
                c = GameObject.Instantiate(plotPrefap, CanculatePosition(i), Quaternion.identity) as GameObject;
            }
            c.transform.parent = this.transform.GetChild(0);

            _plots[i] = c.GetComponent<Plot>();

            // set color for plot
            if (i % 3 == 0 )
            {
                _plots[i].Color = EPlotColor.BLUE;
            } 
            if ( i % 4 == 0)
            {
                _plots[i].Color = EPlotColor.RED;
            }
            //_plots[i].count = 1;
           
            
            
          
            
           
        }
    }

    public Vector3 CanculatePosition(int i)
    {
        float SIZE = plotPrefap.GetComponent<Plot>().SIZE;
        Vector3 base1 = new Vector3(basePosition.x, 0, basePosition.z);
        Vector3 base2 = new Vector3(basePosition.x , 0, basePosition.z + 8 * SIZE);
        Vector3 base3 = new Vector3(basePosition.x + 8*SIZE, 0, basePosition.z + 8 * SIZE);
        Vector3 base4 = new Vector3(basePosition.x + 8 * SIZE, 0, basePosition.z );
        if (i < 8)
        {
            if (i == 0)
            {
                return new Vector3(base1.x - 0.5f, base1.y, base1.z - 0.5f);
            }
            return new Vector3(base1.x, base1.y, base1.z + i * SIZE);
        }
        else if (i < 16)
        {
            if (i == 8)
            {
                return new Vector3(base2.x - 0.5f, base2.y, base2.z + 0.5f);
            }
            return new Vector3(base2.x + (i % 8) * SIZE, base2.y, base2.z);
        }
        else if (i < 24)
        {
            if (i == 16)
            {
                return new Vector3(base3.x + 0.5f, base3.y, base3.z + 0.5f);
            }
            return new Vector3(base3.x, base3.y, base3.z - (i % 8) * SIZE);
        }
        else
        {
            if (i == 24)
            {
                return new Vector3(base4.x + 0.5f, base4.y, base4.z - 0.5f);
            }
            return new Vector3(base4.x - (i % 8) * SIZE, base4.y, base4.z);
        }
    }
}
