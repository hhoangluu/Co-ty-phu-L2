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
    public EPlayer Player { get => _player; set => _player = value; }
   

    public void Init()
    {
        _isMove = false;
        _position = 0;
        _player = EPlayer.RED;
    }

    public void Move(int point)
    {
        _isMove = true;
        Sequence s = DOTween.Sequence();
        while (point > 0)
        {
            if(_position > 30)
            {
                _position -= 32;
            }
            s.Append(transform.DOMove(CanculatePosition(++_position), 0.1f));
            point--;
        }


    }

    public void PlayerUpdate()
    {
        if (transform.position == CanculatePosition(_position))
        {
            _isMove = false;
        }
    }
    private Vector3 CanculatePosition(int pos)
    {
        var newpos = Map.Current.CanculatePosition(pos);
        
        if (_position < 9)
        {
          //  Debug.Log("Vi tri tinh toan " + newpos);
            newpos.x = Map.Current.BotLeftMargin;
            newpos.y = transform.position.y;

        }
        else if (_position < 17)
        {
         //   Debug.Log("Vi tri tinh toan " + newpos +" " + _position);
            newpos.z = Map.Current.TopRightMargin;
            newpos.y = transform.position.y;
        }
        else if (_position < 25)
        {
            //   Debug.Log("Vi tri tinh toan " + newpos +" " + _position);
            newpos.x = Map.Current.TopRightMargin;
            newpos.y = transform.position.y;
        }
        else if (_position < 32)
        {
            //   Debug.Log("Vi tri tinh toan " + newpos +" " + _position);
            newpos.z = Map.Current.BotLeftMargin;
            newpos.y = transform.position.y;
        }
        return newpos;
    }
}
