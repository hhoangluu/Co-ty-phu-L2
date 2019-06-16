using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;
    public PlayerInfo playerinfo;
    public GameObject Dice;

    //public GameObject MapO;
    public GameObject[] player;
    public DiceModel diceModel;
    public PlayerModel meModel;

    public PlayerModel[] playerModels;
    public static GameObject Me;
    public GameObject[] playerO;
    GameInfoModel gameinfo;
    public EPlayer turn;
    public PlayerInfo meinfo = new PlayerInfo();
    Firebase.Database.DatabaseReference Gamedbref;

    public bool IsInitDone { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
       // GameInfoModel.IdGame = "-Lh9QfqIZn_7EIoH2atL";
        gameinfo = new GameInfoModel();
        Gamedbref = GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame);
        playerModels = new PlayerModel[3];
        playerO = new GameObject[3];
        
        StartCoroutine(InitPlayerFromDB());
         

        diceModel = Dice.GetComponent<DiceModel>();
        //Map.Current = MapO.GetComponent<Map>();

        diceModel.Init();
        //Map.Current.Init();

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
       // Map.Current.ShowWorldCup();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Turn " + turn);
            diceModel.PourDice();
           

        }
        if (diceModel.IsPourDone() && !meModel.IsMove && meModel.Player == turn )
        {
            if (meModel.Countdown == 0)
            {
                meModel.Move(diceModel.Point);

            }
            //  Debug.Log("Turn " + turn);
            StartCoroutine(Play());




        }
        for (int i = 0; i < GameInfoModel.playerCount - 1; i++)
        {

            if (diceModel.IsPourDone() && !playerModels[i].IsMove && playerModels[i].Player == turn)
            {
                if (playerModels[i].Countdown == 0)
                {
                    playerModels[i].Move(diceModel.Point);

                }
                

                //StartCoroutine(Play());
                NextTurn();


            }

        }


        if (IsInitDone == true)
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
                turn = EPlayer.RED;
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
        if (meModel.Player == turn)
        {
            Map.Current.ShowDeal(meModel.Position);
            NextTurn();
        }
        
    }

    IEnumerator Play()
    {
        yield return new WaitWhile(() => meModel.IsMove == true);
        //   playerModel.GetComponent<Animator>().enabled = false;
        subtractMoney(meModel.Position);
        Deal();
        meModel.Push();
        for(int i=0; i< GameInfoModel.playerCount-2; i++)
        {
            playerModels[i].Push();
        }
    }

    public void subtractMoney(int pos)
    {
        if(meModel.Player != Map.Current.Ar_BuidingModel[pos].Player)
        {
            meModel.Money -= Map.Current.Ar_BuidingModel[pos].Fees;
            for (int i=0; i < GameInfoModel.playerCount -2; i++)
            {
                if (playerModels[i].Player == Map.Current.Ar_BuidingModel[pos].Player)
                {
                    playerModels[i].Money += Map.Current.Ar_BuidingModel[pos].Fees;
                    
                    for (int j = 0; i < GameInfoModel.playerCount - 2; i++)
                    {
                        playerModels[j].Push();
                    }
                }
            }
        }
    }

    public void BuyBuilding1()  //Nhà lv1
    {
        Debug.Log("Map.Current.Ar_BuidingModel[meModel.Position].level = " + Map.Current.Ar_BuidingModel[meModel.Position].Level);
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 0
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
            //Map.Current.InitBuilding1(meModel.Position, meModel.Player.ToString());
            Map.Current.Ar_BuidingModel[meModel.Position].Level = 1;
            Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 0.5f;
            meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price;
            meModel.Push();
            Debug.Log("Money = " + meModel.Money);
            Map.Current.pushBuilding(meModel.Position);
        }
        Map.Current.hideDeal(meModel.Position);
        Map.Current.Ar_BuidingModel[meModel.Position].Level = 0;

    }

    public void BuyBuilding2()  //Nhà lv2
    {
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level < 2
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
            if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 0)
            {
                //Map.Current.InitBuilding1(meModel.Position, meModel.Player.ToString());
                //Map.Current.InitBuilding2(meModel.Position, meModel.Player.ToString());
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 2;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                meModel.Push();
                Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f;

                Map.Current.pushBuilding(meModel.Position);
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 0;

            }
            else
            {
                //Map.Current.InitBuilding2(meModel.Position, meModel.Player.ToString());
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 2;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                meModel.Push();
                Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f;
                Map.Current.pushBuilding(meModel.Position);
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 1;
            }

            Debug.Log("Money = " + meModel.Money);


        }
        Map.Current.hideDeal(meModel.Position);
    }

    public void BuyBuilding3()  //Nhà lv3
    {
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level < 3
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
            if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 0)
            {
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 3;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f * 1.5f;

                meModel.Push();               
                Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                Map.Current.pushBuilding(meModel.Position);
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 0;
            }
            else if(Map.Current.Ar_BuidingModel[meModel.Position].Level == 1)
            {
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 3;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f * 1.5f;
                meModel.Push();               
                Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                Map.Current.pushBuilding(meModel.Position);
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 1;
            }
            else
            {
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 3;
                meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f * 1.5f;
                Map.Current.Ar_BuidingModel[meModel.Position].Fees = Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f;
                Map.Current.pushBuilding(meModel.Position);
                Map.Current.Ar_BuidingModel[meModel.Position].Level = 2;
            }


            Debug.Log("Money = " + meModel.Money);

        }
        Map.Current.hideDeal(meModel.Position);
    }
    public void BuyWonders()    //Xây kì quan
    {
        Debug.Log("lol.................");
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3
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
            meModel.Money -= Map.Current.Ar_BuidingModel[meModel.Position].Price * 1.5f * 1.5f * 1.5f *1.5f;
            meModel.Push();
            Map.Current.Ar_BuidingModel[meModel.Position].Level = 4;
            Debug.Log("playerModel.Position: " + meModel.Position + " kq");
        }
        Map.Current.pushBuilding(meModel.Position);
        Map.Current.hideDeal(meModel.Position);
    }
    public void Minigame()  //Minigame
    {
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 2
            )
        {
            //Map.Current.InitWonders(playerModel.Position, meModel.Player.ToString());
        }
        Map.Current.hideDeal(meModel.Position);
    }
    public void PrisonWait3Turn()    //Vào tù
    {
        if (meModel.Countdown == 0 && meModel.Position == 8 && meModel.Player == turn)
        {

            meModel.Countdown = 0;
           
        }
        else if (meModel.Countdown != 0 && meModel.Player == turn)
        {
            meModel.Countdown--;
           if (diceModel.IsDouble == true)
            {
                meModel.Countdown = 0;
            }

        }
        //for (int i = 0; i < GameInfoModel.playerCount - 1; i++)
        //{
        //    if (playerModels[i].Countdown == 0 && playerModels[i].Position == 8 && playerModels[i].player == turn)
        //    {
        //        playerModels[i].Countdown = 3;
        //    }
        //    else if (playerModels[i].Countdown != 0)
        //    {
        //        playerModels[i].Countdown--;
        //    }
        //}
        Debug.Log("me model Countdown " + meModel.Countdown);
        Map.Current.hideDeal(meModel.Position);
    }


    public void WorldCup()    //WorldCup
    {
        if (meModel.Position == 16)
        {

        }
        Map.Current.hideDeal(meModel.Position);
    }
   
    public void Travel()    //Du lịch
    {
        if (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3
            && meModel.Position == 24
            )
        {
            //Map.Current.InitWonders(playerModel.Position, meModel.Player.ToString());
        }
        Map.Current.hideDeal(meModel.Position);
    }
    public void HonDao()    //địa điểm du lịch
    {
        if ((Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 9)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 14)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 18)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 25)
            )
        {
            //Map.Current.InitWonders(playerModel.Position, meModel.Player.ToString());
        }
        Map.Current.hideDeal(meModel.Position);
    }
    public void Chance()    //Cơ hội
    {
        if ((Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 12)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 20)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 28)
            )
        {
            //Map.Current.InitWonders(playerModel.Position, meModel.Player.ToString());
        }
        Map.Current.hideDeal(meModel.Position);
    }
    public void Thue()    //Thuế
    {
        if ((Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 4)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 12)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 20)
            || (Map.Current.Ar_BuidingModel[meModel.Position].Level == 3 && meModel.Position == 28)
            )
        {
            //Map.Current.InitWonders(playerModel.Position, meModel.Player.ToString());
        }
        Map.Current.hideDeal(meModel.Position);
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
      //  meModel.Uid = "jPcRxegAFLNC7Yt1sDs8Vmg0SYM2";
        meinfo.Uid = meModel.Uid;
        Gamedbref.Child("player").Child(meinfo.Uid).SetRawJsonValueAsync(JsonUtility.ToJson(meinfo));
        IsInitDone = true;
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
            playerO[0] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            playerModels[0] = playerO[0].GetComponent<PlayerModel>();
            playerModels[0].Init();
            playerModels[0].Player = EPlayer.RED;
            playerO[1] = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            playerModels[1] = playerO[1].GetComponent<PlayerModel>();
            playerModels[1].Init();
            playerModels[1].Player = EPlayer.BLUE;
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
        meModel.GetAllPlayer();
    }
    IEnumerator InitPlayerFromDB()
    {
        yield return new WaitWhile(() => GameInfoModel.isGetCountDone == false);

        InitMe();
        InitPlayer();
        
    }

}
