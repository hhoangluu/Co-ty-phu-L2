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
    public int playerCount;
    public string Turn;
    public DiceInfo diceInfo;
    public PlayerInfo playerInfo;

    public GameInfoModel()
    {
        

        playerCount = 1;
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
        string json ="";

            json = "{\"Items\":{\"playercount\":\"" + playerCount+ "\",\"player\": {\"" + playerInfo.Uid+"\": "+ JsonUtility.ToJson(playerInfo) +"},\"Turn\":\"RED\",\"Dice\":"+ JsonUtility.ToJson(diceInfo) + "}}";
          return json;
    }

    

}
