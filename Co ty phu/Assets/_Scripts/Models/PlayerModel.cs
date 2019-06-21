using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Firebase.Database;

public class PlayerModel : MonoBehaviour
{


    private EPlayer _player;

    public float _money;

    private int _card;

    private int _position;

    private bool _isMove;

    public int Countdown { get; set; }
    public float Money { get => _money; set => _money = value; }
    public int Card { get => _card; set => _card = value; }
    public int Position { get => _position; set => _position = value; }
    public bool IsMove { get => _isMove; set => _isMove = value; }
    public EPlayer Player { get => _player; set => _player = value; }
    public string username;

    public string Uid;

    public bool checkDoubleColor(int x, int y)
    {
        if (Map.Current.Ar_BuidingModel[x].Owner == Player && Map.Current.Ar_BuidingModel[y].Owner == Player)
        {
            return true;
        }
        return false;
    }

    public bool check3DoubleColor()
    {

        int dem = 0;
        if (checkDoubleColor(1, 3))
        {
            dem++;
        }
        if (checkDoubleColor(10, 11))
        {
            dem++;
        }
        if (checkDoubleColor(13, 15))
        {
            dem++;
        }
        if (checkDoubleColor(17, 19))
        {
            dem++;
        }
        if (checkDoubleColor(26, 27))
        {
            dem++;
        }
        if (checkDoubleColor(29, 31))
        {
            dem++;
        }
        if (dem >=3)
        {
            Debug.Log("mau " + Player.ToString() + "hoan thanh 3 cap mau");
            return true;
        }
        return false;
    }

    public bool check6Island()
    {
        int dem = 0;
        for (int i = 0; i < 32; i++)
        {
            if ((Map.Current.Ar_BuidingModel[i].Owner == Player && i == 2)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 4)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 9)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 12)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 14)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 18)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 20)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 25)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 28)
                || (Map.Current.Ar_BuidingModel[i].Owner == Player && i == 30)
                )
            {
                dem++;
            }
            if (dem == 6)
            {
                Debug.Log("mau " + Player.ToString() + "hoan thanh 6 dao");
                return true;
            }
        }
        return false;
    }
    public bool check3PlayerBankrupt()
    {
        for (int i = 0; i < GameInfoModel.playerCount - 1; i++)
        {
            if (!GameController.instance.playerModels[i].checkBankrupt())
            {
                return false;
            }
        }
        if (GameInfoModel.playerCount == 1)
        {
            return false;
        }
        return true;
    }

    public bool checkBankrupt()
    {
        if (Money <= 0)
        {
            for (int i = 0; i < 32; i++)
            {
                if (Map.Current.Ar_BuidingModel[i].Owner == Player)
                {
                    for (int j = 0; j < Map.Current.Ar_BuidingModel[i].Level; j++)
                    {
                        Money += Map.Current.Ar_BuidingModel[i].Price * 1.5f;
                    }
                }
                if (Money > 0)
                {
                    return false;
                }
            }
            Debug.Log("mau " + Player.ToString() + "pha san");
            Debug.Log("money = " + Money);
            return true;
        }
        return false;
        
    }

    public bool checkWin()
    {
        if (check6Island() || check3PlayerBankrupt() || check3DoubleColor())
        {
            return true;
        }
        return false;
    }

    public PlayerModel()
    {
        Money = 50000;
    }
    public void Init()
    {
        Uid = LoginModel.userID;
        username = LoginModel.username;
        _isMove = false;
        _position = 0;
        _player = EPlayer.RED;
        Money = 50000;
        _card = 0;
        Countdown = 0;
        GameInfoModel.mDatabaseRef.Child(GameInfoModel.IdGame).Child("player").Child(Uid)
      .ValueChanged += HandlePlayerChange;
    }

    public void Move(int point)
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
        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("player").GetValueAsync()
   .ContinueWith(task =>
   {
       if (task.IsFaulted)
       {
           Debug.Log("Errrrrrrrrrrrr");
       }
       else if (task.IsCompleted)
       {
           int count = GameInfoModel.playerCount - 1;
           DataSnapshot snapshot = task.Result;
           Debug.Log("playercount Get all" + snapshot.ChildrenCount);
           foreach (var item in snapshot.Children)
           {
               Debug.Log("item.key.to string" + item.Key.ToString() + "count" + count);
               if (item.Key.ToString() != LoginModel.userID)
               {
                   GameController.instance.playerModels[count].Uid = item.Key.ToString();

                   Debug.Log("item.key.to string" + item.Key.ToString());

               }
               count--;

           }
       }
   });
        // GameInfoModel.mDatabaseRef.Child(GameInfoModel.IdGame).Child("playercount")
        //  .ValueChanged += HandleValueChanged;
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

    public void Push()
    {
        PlayerInfo info = new PlayerInfo();
        info.Uid = Uid;
        info.Money = Money;
        info.Position = _position;
        info.color = Player.ToString();
        info.Countdown = Countdown;
        info.username = username;
        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("player").Child(Uid).SetRawJsonValueAsync(JsonUtility.ToJson(info));
    }

    void HandlePlayerChange(object sender, ValueChangedEventArgs args)
    {

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        DataSnapshot snapshot = args.Snapshot;
        Uid = snapshot.Child("Uid").Value.ToString();
        Money = float.Parse(snapshot.Child("Money").Value.ToString());
        Position = int.Parse(snapshot.Child("Position").Value.ToString());
        Countdown = int.Parse(snapshot.Child("Countdown").Value.ToString());
        username = snapshot.Child("username").Value.ToString();
        if (snapshot.Child("color").Value.ToString() == "RED")
        {
            Player = EPlayer.RED;
        }
        else if (snapshot.Child("color").Value.ToString() == "BLUE")
        {
            Player = EPlayer.BLUE;

        }
        else if (snapshot.Child("color").Value.ToString() == "GREEN")
        {

            Player = EPlayer.GREEN;
        }
        else
        {
            Player = EPlayer.YELLOW;
        }
    }

}
