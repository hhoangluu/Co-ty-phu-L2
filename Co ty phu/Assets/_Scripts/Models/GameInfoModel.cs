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

    public bool isGetCountDone;

    public GameInfoModel()
    {

        playerCount = 0;
        FirebaseDatabase.DefaultInstance
      .GetReference("Game")
       .ValueChanged += HandleValueChanged;

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
                    if (count == "1")
                    {
                        playerCount = 1;
                    }
                    if (count == "0")
                    {
                        playerCount = 0;
                    }
                    if (count == "2")
                    {
                        playerCount = 2;
                    }
                    if (count == "3")
                    {
                        playerCount = 3;
                    }
                    playerCount++;
                    Debug.Log("DAy la playercount"+ playerCount);
                    isGetCountDone = true;
                    GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("playercount").SetValueAsync(GameInfoModel.playerCount.ToString());
                    Debug.Log("Day la player count day len" + GameInfoModel.playerCount);
                    isGetCountDone = false;

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

        count = snapshot.Child(IdGame).Child("playercount").Value.ToString();
        if (count == "2")
        {
            playerCount = 2;
        }
        if (count == "1")
        {
            playerCount = 1;
        }
        if (count == "3")
        {
            playerCount = 3;
        }
        if (count == "4")
        {
            playerCount = 4;
        }
        Debug.Log("Day la count khi thay doi db" + playerCount);
        // Do something with the data in args.Snapshot
    }

}
