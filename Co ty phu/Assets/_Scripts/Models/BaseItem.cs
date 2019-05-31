using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{

    [SerializeField]
    private EPlayer _player;
    public EPlayer Player { get => _player; protected set => _player = value; }
    private Vector2 _location;
    public Vector2 Location { get { return _location; } set { _location = value; } }


    private EPlotColor _color;
    public EPlotColor Color { get => _color; set => _color = value; }
   
}
