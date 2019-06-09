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

    public void SetBuildingLocationById(int id)
    {
        
        this.transform.position = new Vector3(Map.Current.BotLeftMargin + 2.5f, this.transform.position.y + 1, Map.Current.BotLeftMargin + id * Map.Current.PlotSize + 0.5f * Map.Current.PlotSize); // vì mảnh đất dọc dài hơn ngang 2 lần
        //Debug.Log("position"+ this.transform.position);
    }

    

    public void Init()
    {
        
    }
}
