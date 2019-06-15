using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerInfo playerinfo;
    public GameObject Dice;

    public GameObject Map;
    public GameObject[] player;
    private DiceModel diceModel;
    private PlayerModel meModel;

    private PlayerModel[] playerModels;
    private GameObject Me;
    private GameObject[] playerO;
    private Map mapModel;
    GameInfoModel gameinfo;
    private EPlayer turn;
    private PlayerInfo meinfo = new PlayerInfo();
    Firebase.Database.DatabaseReference Gamedbref;
    void Start()
    {
        GameInfoModel.IdGame = "-Lh9QfqIZn_7EIoH2atL";
        gameinfo = new GameInfoModel();
        Gamedbref = GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame);
        playerModels = new PlayerModel[3];
        playerO = new GameObject[3];
        
        StartCoroutine(InitPlayerFromDB());
         

        diceModel = Dice.GetComponent<DiceModel>();
        mapModel = Map.GetComponent<Map>();

        diceModel.Init();
        mapModel.Init();

        turn = EPlayer.RED;
        //if (GameInfoModel.playerCount == 0)
        //{
        //    Gamedbref.SetRawJsonValueAsync(gameinfo.ToJson());
        //    Debug.Log("Hello");
        //}
        //else 


        string json = JsonUtility.ToJson(meinfo);
        //  Debug.Log(json);
      //  json = "{\"" + meModel.Uid + "\":" + json + "}";
       // Gamedbref.Child("Turn").SetValueAsync("RED");
        //Gamedbref.Child("Players").SetRawJsonValueAsync(json);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Turn " + turn);
            diceModel.PourDice();

        }
        if (diceModel.IsPourDone() && !meModel.IsMove && meModel.Player == turn)
        {

            //  Debug.Log("Turn " + turn);
            meModel.Move(diceModel.Point, playerinfo);

            StartCoroutine(Play());
            NextTurn();


        }
        for (int i = 0; i < GameInfoModel.playerCount - 1; i++)
        {

            if (diceModel.IsPourDone() && !playerModels[i].IsMove && playerModels[i].Player == turn)
            {
                Debug.Log("PlayerO Bat dau di chuyen");
                //  Debug.Log("Turn " + turn);
                playerModels[i].Move(diceModel.Point, playerinfo);

                //StartCoroutine(Play());
                NextTurn();


            }

        }


        if (GameInfoModel.isGetCountDone == true)
        {
            diceModel.DiceUpdate();
            meModel.PlayerUpdate();
            for (int i = 0; i < GameInfoModel.playerCount - 1; i++)
            {
                playerModels[i].PlayerUpdate();
            }
        }
    }


    [ContextMenu("Next Turn")]
    void NextTurn()
    {
        diceModel.EndTurn();
        switch (turn)
        {
            case EPlayer.RED:
                turn = EPlayer.BLUE;
                break;
            case EPlayer.BLUE:
                turn = EPlayer.GREEN;
                break;
            case EPlayer.GREEN:
                turn = EPlayer.YELLOW;
                break;
            case EPlayer.YELLOW:
                turn = EPlayer.RED;
                break;

        }
    }

    void Deal()
    {
        Debug.Log("Đang ở ô đất số " + meModel.Position);

        mapModel.ShowDeal(meModel.Position);
    }

    IEnumerator Play()
    {
        yield return new WaitWhile(() => meModel.IsMove == true);
        //   playerModel.GetComponent<Animator>().enabled = false;
        Deal();
    }

    public void BuyBuilding1()  //Nhà lv1
    {

        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 0
            && meModel.Position != 0
            && meModel.Position != 2
            && meModel.Position != 4
            && meModel.Position != 8
            && meModel.Position != 9
            && meModel.Position != 12
            && meModel.Position != 14
            && meModel.Position != 16
            && meModel.Position != 18
            && meModel.Position != 20
            && meModel.Position != 24
            && meModel.Position != 25
            && meModel.Position != 28
            && meModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + meModel.Position + " lv1");
            mapModel.InitBuilding1(meModel.Position, "Red");
            mapModel.Ar_BuidingModel[meModel.Position].Level++;
            meModel.Money -= mapModel.Ar_BuidingModel[meModel.Position].buy_Price;
            mapModel.Ar_BuidingModel[meModel.Position].sell_Price = mapModel.Ar_BuidingModel[meModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[meModel.Position].buy_Price = mapModel.Ar_BuidingModel[meModel.Position].Price;

            Debug.Log("Money = " + meModel.Money);

            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[meModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[meModel.Position].buy_Price);
        }
        mapModel.hideDeal(meModel.Position);
    }

    public void BuyBuilding2()  //Nhà lv2
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level < 2
            && meModel.Position != 0
            && meModel.Position != 2
            && meModel.Position != 4
            && meModel.Position != 8
            && meModel.Position != 9
            && meModel.Position != 12
            && meModel.Position != 14
            && meModel.Position != 16
            && meModel.Position != 18
            && meModel.Position != 20
            && meModel.Position != 24
            && meModel.Position != 25
            && meModel.Position != 28
            && meModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + meModel.Position + " lv2");

            mapModel.InitBuilding2(meModel.Position, "Red");
            mapModel.Ar_BuidingModel[meModel.Position].Level++;

            mapModel.Ar_BuidingModel[meModel.Position].Level++;
            meModel.Money -= mapModel.Ar_BuidingModel[meModel.Position].buy_Price;
            mapModel.Ar_BuidingModel[meModel.Position].sell_Price = mapModel.Ar_BuidingModel[meModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[meModel.Position].buy_Price = mapModel.Ar_BuidingModel[meModel.Position].Price;

            Debug.Log("Money = " + meModel.Money);

            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[meModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[meModel.Position].buy_Price);

        }
        mapModel.hideDeal(meModel.Position);
    }

    public void BuyBuilding3()  //Nhà lv3
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level < 3
            && meModel.Position != 0
            && meModel.Position != 2
            && meModel.Position != 4
            && meModel.Position != 8
            && meModel.Position != 9
            && meModel.Position != 12
            && meModel.Position != 14
            && meModel.Position != 16
            && meModel.Position != 18
            && meModel.Position != 20
            && meModel.Position != 24
            && meModel.Position != 25
            && meModel.Position != 28
            && meModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + meModel.Position + " lv3");

            mapModel.InitBuilding3(meModel.Position, "Red");
            mapModel.Ar_BuidingModel[meModel.Position].Level++;
            meModel.Money -= mapModel.Ar_BuidingModel[meModel.Position].buy_Price;
            mapModel.Ar_BuidingModel[meModel.Position].sell_Price = mapModel.Ar_BuidingModel[meModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[meModel.Position].buy_Price = mapModel.Ar_BuidingModel[meModel.Position].Price;

            Debug.Log("Money = " + meModel.Money);


            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[meModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[meModel.Position].buy_Price);
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void BuyWonders()    //Xây kì quan
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position != 0
            && meModel.Position != 2
            && meModel.Position != 4
            && meModel.Position != 8
            && meModel.Position != 9
            && meModel.Position != 12
            && meModel.Position != 14
            && meModel.Position != 16
            && meModel.Position != 18
            && meModel.Position != 20
            && meModel.Position != 24
            && meModel.Position != 25
            && meModel.Position != 28
            && meModel.Position != 30
            )
        {
            //Hủy nhà 1 2 3
            //...............
            //
            Debug.Log("playerModel.Position: " + meModel.Position + " kq");
            mapModel.InitWonders(meModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void Minigame()  //Minigame
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 2
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void Prison()    //Cơ hội
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 8
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void WorldCup()    //WorldCup
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 16
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void Travle()    //Du lịch
    {
        if (mapModel.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 24
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void HonDao()    //địa điểm du lịch
    {
        if ((mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 9)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 14)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 18)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 25)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void Chance()    //Cơ hội
    {
        if ((mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 12)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 20)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 28)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }
    public void Thue()    //Thuế
    {
        if ((mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 12)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 20)
            || (mapModel.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 28)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(meModel.Position);
    }

    private void InitMe()
    {



        var count = GameInfoModel.playerCount;
        //   diceCTL = Dice.GetComponent<DiceCTL>();
        //   playerCTL = Player.GetComponent<PlayerCTL>();

        if (count == 1)
        {
            Me = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            Debug.Log("Khoi tao thanh cong player 1");
            meModel = Me.GetComponent<PlayerModel>();
            Debug.Log("Khoi tao thanh cong player 2");
            meModel.Init();
            meModel.Player = EPlayer.RED;

        }
        else if (count == 2)
        {
            Me = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            meModel = Me.GetComponent<PlayerModel>();
            meModel.Init();
            meModel.Player = EPlayer.BLUE;
        }
        else if (count == 3)
        {
            Me = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerGreen")) as GameObject;
            meModel = Me.GetComponent<PlayerModel>();
            meModel.Init();
            meModel.Player = EPlayer.GREEN;
        }
        else if (count == 4)
        {
            Me = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerYellow")) as GameObject;
            meModel = Me.GetComponent<PlayerModel>();
            meModel.Init();
            meModel.Player = EPlayer.YELLOW;
        }
        meModel.Uid = "jPcRxegAFLNC7Yt1sDs8Vmg0SYM2";
        meinfo.Uid = meModel.Uid;
        Gamedbref.Child("player").Child(meinfo.Uid).SetRawJsonValueAsync(JsonUtility.ToJson(meinfo));
    }

    private void InitPlayer()
    {
        int count = GameInfoModel.playerCount;
        Debug.Log("So luong cac player khac " + count);
        if (count == 2)
        {
            playerO[0] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            playerModels[0] = playerO[0].GetComponent<PlayerModel>();
            playerModels[0].Init();
            playerModels[0].Player = EPlayer.RED;
        }
        else if (count == 3)
        {
            playerO[0] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            playerModels[0] = playerO[0].GetComponent<PlayerModel>();
            playerModels[0].Init();
            playerModels[0].Player = EPlayer.BLUE;
            playerO[1] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerGreen")) as GameObject;
            playerModels[1] = playerO[1].GetComponent<PlayerModel>();
            playerModels[1].Init();
            playerModels[1].Player = EPlayer.GREEN;
        }
        else if (count == 4)
        {
            playerO[0] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            playerModels[0] = playerO[0].GetComponent<PlayerModel>();
            playerModels[0].Init();
            playerModels[0].Player = EPlayer.RED;
            playerO[1] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            playerModels[1] = playerO[1].GetComponent<PlayerModel>();
            playerModels[1].Init();
            playerModels[1].Player = EPlayer.BLUE;
            playerO[2] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerGreen")) as GameObject;
            playerModels[2] = playerO[2].GetComponent<PlayerModel>();
            playerModels[2].Init();
            playerModels[2].Player = EPlayer.GREEN;
        }
    }
    IEnumerator InitPlayerFromDB()
    {
        yield return new WaitWhile(() => GameInfoModel.isGetCountDone == false);
        InitMe();
        InitPlayer();
    }

}
