using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    public GameObject plotVerticalPrefap;
    public GameObject plotHorizontalPrefap;

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
            if (i % 8 == 0)
            {
                c = GameObject.Instantiate(bigPlotPrefap, CanculatePosition(i), Quaternion.identity) as GameObject;
              
            }
            else if ((i > 8 && i < 16) || (i < 32 && i > 24))
            {
                c = GameObject.Instantiate(plotHorizontalPrefap, CanculatePosition(i), Quaternion.identity) as GameObject;
            }
            else
            {
                c = GameObject.Instantiate(plotVerticalPrefap, CanculatePosition(i), Quaternion.identity) as GameObject;
            }


            c.transform.parent = this.transform.GetChild(0);

            _plots[i] = c.GetComponent<Plot>();

            // set color for plot
            if (i == 0 || i == 3)
            {
                _plots[i].Color = EPlotColor.GREEN;
            }
            else if (i == 5 || i == 6 || i == 7)
            {
                _plots[i].Color = EPlotColor.RED;
            }
            else if (i == 10 || i == 11)
            {
                _plots[i].Color = EPlotColor.VIOLET;
            }
            else if (i == 13 || i == 15)
            {
                _plots[i].Color = EPlotColor.RED;
            }
            else if (i == 17 || i == 19)
            {
                _plots[i].Color = EPlotColor.GREEN;
            }
            else if (i == 21 || i == 22 || i == 23)
            {
                _plots[i].Color = EPlotColor.VIOLET;
            }
            else if (i == 26 || i == 27)
            {
                _plots[i].Color = EPlotColor.YELLOW;
            }
            else if (i == 29 || i == 31)
            {
                _plots[i].Color = EPlotColor.VIOLET;
            }

            //_plots[i].count = 1;






        }
    }

    public Vector3 CanculatePosition(int i)
    {
        float SIZE = plotHorizontalPrefap.GetComponent<Plot>().SIZEX;
        float SIZEY = bigPlotPrefap.GetComponent<Plot>().SIZEBig;

        //Debug.Log(SIZE);
        Vector3 base1 = new Vector3(basePosition.x, 0, basePosition.z);
        Vector3 base2 = new Vector3(basePosition.x , 0, basePosition.z + 8 * SIZE);
        Vector3 base3 = new Vector3(basePosition.x + 8*SIZE, 0, basePosition.z + 8 * SIZE);
        Vector3 base4 = new Vector3(basePosition.x + 8 * SIZE, 0, basePosition.z );
        if (i < 8)
        {
            if (i == 0)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEY, base1.y, -3.5f * SIZE - 0.5f * SIZEY);
            }
            //return new Vector3(base1.x -  0.5f*SIZEY, base1.y, base1.z + i * SIZE);
            return new Vector3(-4.5f*SIZE, base1.y, base1.z + i * SIZE);
        }
        else if (i < 16)
        {
            if (i == 8)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEY, base2.y, 3.5f * SIZE + 0.5f * SIZEY);
            }
            return new Vector3(base2.x + (i % 8) * SIZE, base2.y, 4.5f * SIZE);
        }
        else if (i < 24)
        {
            if (i == 16)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEY, base3.y, 3.5f * SIZE + 0.5f * SIZEY);
            }
            return new Vector3(4.5f * SIZE, base3.y, base3.z - (i % 8) * SIZE);
        }
        else
        {
            if (i == 24)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEY, base4.y, -3.5f * SIZE - 0.5f * SIZEY);
            }
            return new Vector3(base4.x - (i % 8) * SIZE, base4.y, -4.5f * SIZE);
        }
    }
}
