using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerModel : MonoBehaviour
{
   

    private EPlayer _player;

    private float _money;

    private int _card;

    private int _position;

    private bool _isMove;

    private float _asset;

    public float Money { get => _money; set => _money = value; }
    public int Card { get => _card; set => _card = value; }
    public int Position { get => _position; set => _position = value; }
    public bool IsMove { get => _isMove; set => _isMove = value; }
    public EPlayer Player { get => _player; set => _player = value; }
    public float Asset { get => _asset; set => _asset = value; }

    public static string Uid;


    public void Init()
    {
        Uid = "hiZfaSqGovPl55Dv9m4JTxC5wHs1";
        _isMove = false;
        _position = 0;
        _player = EPlayer.RED;
        Money = 2000;
        Asset = 2000;
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
