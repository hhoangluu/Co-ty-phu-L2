using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
    public static Map Current;
    public GameObject plotVerticalPrefap;
    public GameObject plotHorizontalPrefap;
    public GameObject bigPlotPrefap;
    public GameObject Deal;

    private float plot_size = -1;
    public float PlotSize
    {
        get
        {
            if (plot_size < 0)
                plot_size = plotHorizontalPrefap.GetComponent<Plot>().SIZEX;
            return plot_size;
        }
    }

    private float botleft_margin = -1;
    public float BotLeftMargin
    {
        get
        {
            if (botleft_margin < 0)
                botleft_margin = -4.5f * plotHorizontalPrefap.GetComponent<Plot>().SIZEX;
            return botleft_margin;
        }
    }

    private float topright_margin = -1;
    public float TopRightMargin
    {
        get
        {
            if (topright_margin < 0)
                topright_margin = 4.5f * plotHorizontalPrefap.GetComponent<Plot>().SIZEX;
            return topright_margin;
        }
    }


    private List<BaseItem> items= new List<BaseItem>();
    void Awake()
    {
        Current = this;
    }
    public Vector3 basePosition;
    private Plot[] _plots;
    public Plot[] Plots
    {
        get { return _plots; }

    }
    [ContextMenu("check")]
    public void Check()
    {
        Init();
    }
    //[ContextMenu("InitBuilding1-1")]
   
    public void InitBuilding1(int id)
    {
        GameObject Building1 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building1-Blue")) as GameObject;
        Building1.transform.parent = this.transform.GetChild(1);
        Building b1 = Building1.GetComponent<Building>();
        items.Add(b1);
        b1.SetBuilding1LocationById(id); 

    }
    public void InitBuilding2(int id)
    { 
        GameObject Building2 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building2-Red")) as GameObject;
        Building2.transform.parent = this.transform.GetChild(1);
        Building b2 = Building2.GetComponent<Building>();
        items.Add(b2);
        b2.SetBuilding2LocationById(id);
    }

    public void InitBuilding3(int id)
    {
        GameObject Building3 = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Items/Building3-Red")) as GameObject;
        Building3.transform.parent = this.transform.GetChild(1);
        Building b3 = Building3.GetComponent<Building>();
        items.Add(b3);
        b3.SetBuilding3LocationById(id);
    }


    public void Init()
    {
        _plots = new Plot[32];
        for (int i = 0; i < 32; i++)
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
            c.GetComponent<Collider>().tag = "Plot";
            _plots[i] = c.GetComponent<Plot>();
            _plots[i].name = "plot " + i;
            
            // set color for plot
            if (i == 1 || i == 3)
            {
                _plots[i].Color = EPlotColor.COLOR1;
            }
            else if (i == 5 || i == 6 || i == 7)
            {
                _plots[i].Color = EPlotColor.COLOR2;
            }
            else if (i == 10 || i == 11)
            {
                _plots[i].Color = EPlotColor.COLOR3;
            }
            else if (i == 13 || i == 15)
            {
                _plots[i].Color = EPlotColor.COLOR4;
            }
            else if (i == 17 || i == 19)
            {
                _plots[i].Color = EPlotColor.COLOR5;
            }
            else if (i == 21 || i == 22 || i == 23)
            {
                _plots[i].Color = EPlotColor.COLOR6;
            }
            else if (i == 26 || i == 27)
            {
                _plots[i].Color = EPlotColor.COLOR7;
            }
            else if (i == 29 || i == 31)
            {
                _plots[i].Color = EPlotColor.COLOR8;
            }
            else
            {
                _plots[i].Color = EPlotColor.WHITE;
            }
            //_plots[i].count = 1;






        }
    }

   

    public Vector3 CanculatePosition(int i)
    {
        float SIZE = plotHorizontalPrefap.GetComponent<Plot>().SIZEX;
        float SIZEY = plotHorizontalPrefap.GetComponent<Plot>().SIZEY;
        float SIZEBig = bigPlotPrefap.GetComponent<Plot>().SIZEBig;

        //Debug.Log(SIZE);
        Vector3 base1 = new Vector3(basePosition.x, 0, basePosition.z);
        Vector3 base2 = new Vector3(basePosition.x, 0, basePosition.z + 8 * SIZE);
        Vector3 base3 = new Vector3(basePosition.x + 8 * SIZE, 0, basePosition.z + 8 * SIZE);
        Vector3 base4 = new Vector3(basePosition.x + 8 * SIZE, 0, basePosition.z);
        if (i < 8)
        {
            if (i == 0)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEBig, base1.y, -3.5f * SIZE - 0.5f * SIZEBig);
            }
            //return new Vector3(base1.x -  0.5f*SIZEY, base1.y, base1.z + i * SIZE);
            return new Vector3(-4.5f * SIZE, base1.y, base1.z + i * SIZE);
        }
        else if (i < 16)
        {
            if (i == 8)
            {
                return new Vector3(-3.5f * SIZE - 0.5f * SIZEBig, base2.y, 3.5f * SIZE + 0.5f * SIZEBig);
            }
            return new Vector3(base2.x + (i % 8) * SIZE, base2.y, 4.5f * SIZE);
        }
        else if (i < 24)
        {
            if (i == 16)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEBig, base3.y, 3.5f * SIZE + 0.5f * SIZEBig);
            }
            return new Vector3(4.5f * SIZE, base3.y, base3.z - (i % 8) * SIZE);
        }
        else
        {
            if (i == 24)
            {
                return new Vector3(3.5f * SIZE + 0.5f * SIZEBig, base4.y, -3.5f * SIZE - 0.5f * SIZEBig);
            }
            return new Vector3(base4.x - (i % 8) * SIZE, base4.y, -4.5f * SIZE);
        }
    }

    public void ShowDeal()
    {
        Deal.active = true;
    }

    public void hideDeal()
    {
        Deal.active = false;
    }
}
