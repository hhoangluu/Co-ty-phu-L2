using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class GameInfoModel
{

    public static DatabaseReference mDatabaseRef; // ROOT
    public static string IdGame;
    public static int playerCount;
    public string Turn;
    public DiceInfo diceInfo;
    public PlayerInfo playerInfo;

    public static bool isGetCountDone;

    public GameInfoModel()
    {

        playerCount = 0;
       

        Turn = "RED";
        diceInfo = new DiceInfo();
        playerInfo = new PlayerInfo();
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://monopoly-14e94.firebaseio.com/");

        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        

    }
    

    public string ToJson()
    {
        string json = "";

        json = "{\"playercount\":\"" + playerCount + "\",\"player\": {\"" + playerInfo.Uid + "\": " + JsonUtility.ToJson(playerInfo) + "},\"Turn\":\"RED\",\"Dice\":" + JsonUtility.ToJson(diceInfo) + "}";
        return json;
    }

    public void GetCount()
    {
        

        string count = "";
        FirebaseDatabase.DefaultInstance.GetReference("Game").Child(IdGame).Child("playercount").GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {

                }
                else if (task.IsCompleted)
                {

                    DataSnapshot snapshot = task.Result;

                    count = snapshot.Value.ToString();
                    playerCount = int.Parse(count.ToString());
                    playerCount++;
                    Debug.Log("DAy la playercount"+ playerCount);
                    isGetCountDone = true;
                    GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("playercount").SetValueAsync(GameInfoModel.playerCount.ToString());
                    Debug.Log("Day la player count day len" + GameInfoModel.playerCount);
                   
                    FirebaseDatabase.DefaultInstance
     .GetReference("Game").Child(IdGame).Child("playercount")
      .ValueChanged += HandleValueChanged;
                }
            });


    }




    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        string count = "";
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;

        count = snapshot.Value.ToString();
        if (playerCount == int.Parse(count))
            return;
        playerCount = int.Parse(count.ToString());
        
        Debug.Log("Day la count khi thay doi db " + playerCount);
        GameObject p = null;
        PlayerModel pModel = null;
        if (playerCount == 0)
        {

            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerRed")) as GameObject;
            Debug.Log("Khoi tao thanh cong player 1");
            pModel = p.GetComponent<PlayerModel>();
            Debug.Log("Khoi tao thanh cong player 2");
            pModel.Init();
            pModel.Uid = ""; /// lay username từ players
            pModel.Player = EPlayer.RED;

        }
        else if (playerCount == 2)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerBlue")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.BLUE;
        }
        else if (playerCount == 3)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerGreen")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.GREEN;
        }
        else if (playerCount == 4)
        {
            p = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Players/PlayerYellow")) as GameObject;
            pModel = p.GetComponent<PlayerModel>();
            pModel.Init();
            pModel.Player = EPlayer.YELLOW;
        }
        GameController.instance.playerO[playerCount - 2] = p;
        GameController.instance.playerModels[playerCount - 2] = pModel;
        // Do something with the data in args.Snapshot
    }

}
