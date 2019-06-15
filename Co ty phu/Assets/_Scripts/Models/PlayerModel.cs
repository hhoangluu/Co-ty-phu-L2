using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Firebase.Database;

public class PlayerModel : MonoBehaviour
{


    private EPlayer _player;

    private float _money;

    private int _card;

    private int _position;

    private bool _isMove;


    public float Money { get => _money; set => _money = value; }
    public int Card { get => _card; set => _card = value; }
    public int Position { get => _position; set => _position = value; }
    public bool IsMove { get => _isMove; set => _isMove = value; }
    public EPlayer Player { get => _player; set => _player = value; }
    public EPlayer player;

    public string Uid;


    public void Init()
    {
        Uid = LoginModel.userID;
        _isMove = false;
        _position = 0;
        _player = player;
        Money = 2000;
        _card = 0;
    }

    public void Move(int point, PlayerInfo playerInfo)
    {
        //  GetComponent<Animator>().enabled = true;
        _isMove = true;
        Sequence s = DOTween.Sequence();
        while (point > 0)
        {
            if (_position > 30)
            {
                _position -= 32;
            }

            if (_position == 0)
            {
                s.Append(transform.DORotate(new Vector3(0, 0, 0), 0.5f));
            }
            if (_position == 8)
            {
                s.Append(transform.DORotate(new Vector3(0, 90, 0), 0.5f));
            }
            if (_position == 16)
            {
                s.Append(transform.DORotate(new Vector3(0, 180, 0), 0.5f));
            }
            if (_position == 24)
            {
                s.Append(transform.DORotate(new Vector3(0, 270, 0), 0.5f));
            }
            s.Append(transform.DOJump(CanculatePosition(++_position), 2, 1, 0.5f));
            point--;
            //if (point == 0 && _position )
            //{
            //    s.Append(transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z), 0.5f));
            //}
            //   s.Append(GetComponent<Rigidbody2D>().DOJump(new Vector2(0,0), 4f, 2  , 1));
        }
        //  GetComponent<Animator>().enabled = false;

        //GameInfoModel.mDatabaseRef.Child("Game").Child("player").Child(Uid).SetRawJsonValueAsync(JsonUtility.ToJson(playerInfo));
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

    public void GetAllPlayer()
    {
        GameInfoModel.mDatabaseRef.Child(GameInfoModel.IdGame).Child("playercount")
      .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        var count = 0;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;

        count = int.Parse(snapshot.Value.ToString());
        GameObject p = null;
        PlayerModel pModel;
        if (count == 0)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            Debug.Log("Khoi tao thanh cong player 1");
            pModel = p.GetComponent<PlayerModel>();
            Debug.Log("Khoi tao thanh cong player 2");
            pModel.Init();
            pModel.Uid = ""; /// lay username từ players
            pModel.Player = EPlayer.RED;

        }
        else if (count == 2)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.BLUE;
        }
        else if (count == 3)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerGreen")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.GREEN;
        }
        else if (count == 4)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerYellow")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.YELLOW;
        }

    }
}
