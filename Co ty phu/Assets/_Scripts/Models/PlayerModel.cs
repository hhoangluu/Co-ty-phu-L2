using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerModel : MonoBehaviour
{
    private EPlayer _player;

    private int _money;

    private int _card;

    private int _position;

    private bool _isMove;

    public int Money { get => _money; set => _money = value; }
    public int Card { get => _card; set => _card = value; }
    public int Position { get => _position; set => _position = value; }
    public bool IsMove { get => _isMove; set => _isMove = value; }

    public void Init()
    {
        _isMove = false;
        _position = 0;
    }

    public void Move(int point)
    {
        _isMove = true;
        _position = _position + point;
        if (_position > 31 )
        {
            _position -= 31;
        }
        Debug.Log("dang di chuyen" + point);
        var newpos = Map.Current.CanculatePosition(_position);
        if (_position < 9)
        {
            newpos.x = Map.Current.BotLeftMargin;
            newpos.y = transform.position.y;
           
        }
        transform.DOMove(newpos, 2f);
    }
}
