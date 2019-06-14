using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{

    [SerializeField]
    private EPlayer _player;
    public EPlayer Player
    {
        get => _player; protected set => _player = value;
    }
    public Vector2 Location { get; set; }

    

    private EPlotColor _color;
    public EPlotColor Color { get => _color; set => _color = value; }


    public void SetBuilding1LocationById(int id)
    {
        //Debug.Log("Map.Current.BotLeftMargin = " + Map.Current.BotLeftMargin);
        //Debug.Log("Map.Current.TopRightMargin = " + Map.Current.TopRightMargin);
        Debug.Log("Map.Current.PlotSize = " + Map.Current.PlotSize);
        float x = 0;
        float y = 0;
        float z = 0;
        y = this.transform.position.y + 1;
        if (0 <= id && id <= 8)
        {
            x = Map.Current.BotLeftMargin + 2.5f;
            z = Map.Current.BotLeftMargin + id * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize + 1f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (9 <= id && id <= 16)
        {
            x = Map.Current.BotLeftMargin + (id - 8) * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize + 1f;
            z = Map.Current.TopRightMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (17 <= id && id <= 24)
        {
            x = Map.Current.TopRightMargin + 2.5f;
            z = Map.Current.TopRightMargin - (id - 16) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize + 1f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (25 <= id && id <= 31)
        {
            x = Map.Current.TopRightMargin - (id - 24) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize + 1f;
            z = Map.Current.BotLeftMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }

        this.transform.position = new Vector3(x, y, z); // vì mảnh đất dọc dài hơn ngang 2 lần
        //Debug.Log("position"+ this.transform.position);
    }

    public void SetBuilding2LocationById(int id)
    {
        //Debug.Log("Map.Current.BotLeftMargin = " + Map.Current.BotLeftMargin);
        //Debug.Log("Map.Current.TopRightMargin = " + Map.Current.TopRightMargin);
        Debug.Log("Map.Current.PlotSize = " + Map.Current.PlotSize);
        float x = 0;
        float y = 0;
        float z = 0;
        y = this.transform.position.y + 1;
        if (0 <= id && id <= 8)
        {
            x = Map.Current.BotLeftMargin + 2.5f;
            z = Map.Current.BotLeftMargin + id * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (9 <= id && id <= 16)
        {
            x = Map.Current.BotLeftMargin + (id - 8) * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize;
            z = Map.Current.TopRightMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (17 <= id && id <= 24)
        {
            x = Map.Current.TopRightMargin + 2.5f;
            z = Map.Current.TopRightMargin - (id - 16) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (25 <= id && id <= 31)
        {
            x = Map.Current.TopRightMargin - (id - 24) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize;
            z = Map.Current.BotLeftMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }

        this.transform.position = new Vector3(x, y, z); // vì mảnh đất dọc dài hơn ngang 2 lần
        //Debug.Log("position"+ this.transform.position);
    }

    public void SetBuilding3LocationById(int id)
    {
        //Debug.Log("Map.Current.BotLeftMargin = " + Map.Current.BotLeftMargin);
        //Debug.Log("Map.Current.TopRightMargin = " + Map.Current.TopRightMargin);
        Debug.Log("Map.Current.PlotSize = " + Map.Current.PlotSize);
        float x = 0;
        float y = 0;
        float z = 0;
        y = this.transform.position.y + 4;
        if (0 <= id && id <= 8)
        {
            x = Map.Current.BotLeftMargin + 2.5f;
            z = Map.Current.BotLeftMargin + id * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize - 1f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (9 <= id && id <= 16)
        {
            x = Map.Current.BotLeftMargin + (id - 8) * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize - 1f;
            z = Map.Current.TopRightMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (17 <= id && id <= 24)
        {
            x = Map.Current.TopRightMargin + 2.5f;
            z = Map.Current.TopRightMargin - (id - 16) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize - 1f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (25 <= id && id <= 31)
        {
            x = Map.Current.TopRightMargin - (id - 24) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize - 1f;
            z = Map.Current.BotLeftMargin + 2.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }

        this.transform.position = new Vector3(x, y, z); // vì mảnh đất dọc dài hơn ngang 2 lần
        //Debug.Log("position"+ this.transform.position);
    }

    public void SetWondersLocationById(int id)
    {
        //Debug.Log("Map.Current.BotLeftMargin = " + Map.Current.BotLeftMargin);
        //Debug.Log("Map.Current.TopRightMargin = " + Map.Current.TopRightMargin);
        Debug.Log("Map.Current.PlotSize = " + Map.Current.PlotSize);
        float x = 0;
        float y = 0;
        float z = 0;
        y = this.transform.position.y + 1;
        if (0 <= id && id <= 8)
        {
            x = Map.Current.BotLeftMargin + 2.5f - 0.5f;
            z = Map.Current.BotLeftMargin + id * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (9 <= id && id <= 16)
        {
            x = Map.Current.BotLeftMargin + (id - 8) * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize;
            z = Map.Current.TopRightMargin + 2.5f - 0.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (17 <= id && id <= 24)
        {
            x = Map.Current.TopRightMargin + 2.5f - 0.5f;
            z = Map.Current.TopRightMargin - (id - 16) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }
        else if (25 <= id && id <= 31)
        {
            x = Map.Current.TopRightMargin - (id - 24) * Map.Current.PlotSize - 0.5f * Map.Current.PlotSize;
            z = Map.Current.BotLeftMargin + 2.5f - 0.5f;
            Debug.Log("id = " + id);
            Debug.Log("x = " + x + ", z =" + z);
        }

        this.transform.position = new Vector3(x, y, z); // vì mảnh đất dọc dài hơn ngang 2 lần
        //Debug.Log("position"+ this.transform.position);
    }



    public void Init()
    {
        
    }
}
