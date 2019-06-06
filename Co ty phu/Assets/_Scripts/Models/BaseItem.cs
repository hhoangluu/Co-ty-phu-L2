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

    public void SetLocationById( int id)
    {
        Location = new Vector2();
        this.transform.position = new Vector3(Map.Current.LeftMargin, 0, id * Map.Current.PlotSize);
    }

    

    public void Init()
    {
        
    }
}
