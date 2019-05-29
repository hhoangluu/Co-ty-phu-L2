using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject plotPrefap;
   

    public Vector3 basePosition;
    private Plot[] _plots; 
    public Plot[] Plots
    {
        get { return _plots; }
        
    }
    [ContextMenu("check")]
    public void check()
    {
        Init();
    }
    public void Init()
    {
        _plots = new Plot[32];
        for (int i =0; i< 32; i++)
        {
            GameObject c = GameObject.Instantiate(plotPrefap,CanculatePosition(i) , Quaternion.identity) as GameObject ;
            _plots[i] = c.GetComponent<Plot>();
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
            return new Vector3(base1.x, base1.y, base1.z + i * SIZE);
        }
        else if (i < 16)
        {
            return new Vector3(base2.x + (i % 8) * SIZE, base2.y, base2.z);
        }
        else if (i < 24)
        {
            return new Vector3(base3.x , base2.y, base3.z  - (i % 8) * SIZE);
        }
        else 
            return new Vector3(base4.x - (i % 8) * SIZE, base4.y, base4.z );
    }
}
