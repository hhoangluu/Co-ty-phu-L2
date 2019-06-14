using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public GameObject Dice;
    public GameObject Player;
    public GameObject Map;

    private DiceModel diceModel;
    private PlayerModel playerModel;
    private Map mapModel;
  //  GameInfoModel gameinfo;
    private EPlayer turn;
   // Firebase.Database.DatabaseReference Gamedbref = GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame);
    void Start()
    {
        //   diceCTL = Dice.GetComponent<DiceCTL>();
        //   playerCTL = Player.GetComponent<PlayerCTL>();
        diceModel = Dice.GetComponent<DiceModel>();
        playerModel = Player.GetComponent<PlayerModel>();
        mapModel = Map.GetComponent<Map>();
        diceModel.Init();
        playerModel.Init();
        mapModel.Init();
    //    gameinfo = new GameInfoModel();
        turn = EPlayer.RED;

      //  Gamedbref.SetRawJsonValueAsync(gameinfo.ToJson());

        // string json = JsonUtility.ToJson(playerinfo);
        //  Debug.Log(json);
        //json = "{\""+ PlayerModel.Uid + "\":" + json + "}";
        //Gamedbref.Child("Turn").SetValueAsync("RED");
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
        if (diceModel.IsPourDone() && !playerModel.IsMove /*&& playerModel.Player == turn*/ )
        {
            Debug.Log("Bat dau di chuyen");
            //  Debug.Log("Turn " + turn);
            playerModel.Move(diceModel.Point);

            StartCoroutine(Play());
            NextTurn();


        }


        diceModel.DiceUpdate();
        playerModel.PlayerUpdate();
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
        Debug.Log("Đang ở ô đất số " + playerModel.Position);

        mapModel.ShowDeal(playerModel.Position);
    }

    IEnumerator Play()
    {
        yield return new WaitWhile(() => playerModel.IsMove == true);
     //   playerModel.GetComponent<Animator>().enabled = false;
        Deal();
    }

    public void BuyBuilding1()  //Nhà lv1
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 0
            && playerModel.Position != 0
            && playerModel.Position != 2
            && playerModel.Position != 4
            && playerModel.Position != 8
            && playerModel.Position != 9
            && playerModel.Position != 12
            && playerModel.Position != 14
            && playerModel.Position != 16
            && playerModel.Position != 18
            && playerModel.Position != 20
            && playerModel.Position != 24
            && playerModel.Position != 25
            && playerModel.Position != 28
            && playerModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + playerModel.Position + " lv1");
            mapModel.InitBuilding1(playerModel.Position, "Red");
            mapModel.Ar_BuidingModel[playerModel.Position].Level++;
            playerModel.Money -= mapModel.Ar_BuidingModel[playerModel.Position].buy_Price;
            playerModel.Asset = playerModel.Money + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price;
            mapModel.Ar_BuidingModel[playerModel.Position].sell_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[playerModel.Position].buy_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price;

            Debug.Log("Money = " + playerModel.Money);
            Debug.Log("Asset = " + playerModel.Asset);

            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].buy_Price);
        }
        mapModel.hideDeal(playerModel.Position);
    }

    public void BuyBuilding2()  //Nhà lv2
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level < 2
            && playerModel.Position != 0
            && playerModel.Position != 2
            && playerModel.Position != 4
            && playerModel.Position != 8
            && playerModel.Position != 9
            && playerModel.Position != 12
            && playerModel.Position != 14
            && playerModel.Position != 16
            && playerModel.Position != 18
            && playerModel.Position != 20
            && playerModel.Position != 24
            && playerModel.Position != 25
            && playerModel.Position != 28
            && playerModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + playerModel.Position + " lv2");

            mapModel.InitBuilding2(playerModel.Position, "Red");
            mapModel.Ar_BuidingModel[playerModel.Position].Level++;

            mapModel.Ar_BuidingModel[playerModel.Position].Level++;
            playerModel.Money -= mapModel.Ar_BuidingModel[playerModel.Position].buy_Price;
            playerModel.Asset = playerModel.Money + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price;
            mapModel.Ar_BuidingModel[playerModel.Position].sell_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[playerModel.Position].buy_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price;

            Debug.Log("Money = " + playerModel.Money);
            Debug.Log("Asset = " + playerModel.Asset);

            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].buy_Price);

        }
        mapModel.hideDeal(playerModel.Position);
    }

    public void BuyBuilding3()  //Nhà lv3
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level < 3
            && playerModel.Position != 0
            && playerModel.Position != 2
            && playerModel.Position != 4
            && playerModel.Position != 8
            && playerModel.Position != 9
            && playerModel.Position != 12
            && playerModel.Position != 14
            && playerModel.Position != 16
            && playerModel.Position != 18
            && playerModel.Position != 20
            && playerModel.Position != 24
            && playerModel.Position != 25
            && playerModel.Position != 28
            && playerModel.Position != 30
            )
        {
            Debug.Log("playerModel.Position: " + playerModel.Position + " lv3");

            mapModel.InitBuilding3(playerModel.Position, "Red");
            mapModel.Ar_BuidingModel[playerModel.Position].Level++;
            playerModel.Money -= mapModel.Ar_BuidingModel[playerModel.Position].buy_Price;
            playerModel.Asset = playerModel.Money + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price;
            mapModel.Ar_BuidingModel[playerModel.Position].sell_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price * 2f;
            mapModel.Ar_BuidingModel[playerModel.Position].buy_Price = mapModel.Ar_BuidingModel[playerModel.Position].Price;

            Debug.Log("Money = " + playerModel.Money);
            Debug.Log("Asset = " + playerModel.Asset);

            Debug.Log("sell_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].sell_Price);
            Debug.Log("buy_Price = " + mapModel.Ar_BuidingModel[playerModel.Position].buy_Price);
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void BuyWonders()    //Xây kì quan
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3
            && playerModel.Position != 0
            && playerModel.Position != 2
            && playerModel.Position != 4
            && playerModel.Position != 8
            && playerModel.Position != 9
            && playerModel.Position != 12
            && playerModel.Position != 14
            && playerModel.Position != 16
            && playerModel.Position != 18
            && playerModel.Position != 20
            && playerModel.Position != 24
            && playerModel.Position != 25
            && playerModel.Position != 28
            && playerModel.Position != 30
            )
        {
            //Hủy nhà 1 2 3
            //...............
            //
            Debug.Log("playerModel.Position: " + playerModel.Position + " kq");
            mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void Minigame()  //Minigame
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3
            && playerModel.Position == 2
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void Prison()    //Cơ hội
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3
            && playerModel.Position == 8
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void WorldCup()    //WorldCup
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3
            && playerModel.Position == 16
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void Travle()    //Du lịch
    {
        if (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3
            && playerModel.Position == 24
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void HonDao()    //địa điểm du lịch
    {
        if ((mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 4)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 9)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 14)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 18)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 25)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void Chance()    //Cơ hội
    {
        if ((mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 4)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 12)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 20)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 28)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }
    public void Thue()    //Thuế
    {
        if ((mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 4)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 12)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 20)
            || (mapModel.Ar_BuidingModel[playerModel.Position].Level == 3 && playerModel.Position == 28)
            )
        {
            //mapModel.InitWonders(playerModel.Position, "Red");
        }
        mapModel.hideDeal(playerModel.Position);
    }



}
