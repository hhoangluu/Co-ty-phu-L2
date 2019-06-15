using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LobbyModel : MonoBehaviour
{
    public GameObject canvas;
    public GameObject roomprefaps;
    public GameObject Loading;
    private GameInfoModel info;
    private List<RoomInfo> rooms = new List<RoomInfo>();
    
    private bool IsLoadDone;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject c = GameObject.Instantiate(room, CanculatePosition(1), Quaternion.identity) as GameObject;
        info = new GameInfoModel() ;
      //  info.Turn = 1;
        Debug.Log("Khoi tao info" + info);
        
        GetAllRoom();
        StartCoroutine(RenderRoom());

        
    }

    public void writeNewGame()
    {
        //Debug.Log("Khoi tao info truoc khi chuyen " + info.Dice.Point);
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);

       var a =  GameInfoModel.mDatabaseRef.Child("Game").Push();
        GameInfoModel.IdGame = a.Key;
        a.SetRawJsonValueAsync(json);
        json = "{\"id\":\"" + GameInfoModel.IdGame + "\"}";
        GameInfoModel.mDatabaseRef.Child("Rooms").Child(GameInfoModel.IdGame).SetRawJsonValueAsync(json);
       


        Debug.Log(GameInfoModel.IdGame+ " Day la id game");
        
    }

    public void EnterRoom(int number)
    {
        GameInfoModel.IdGame = rooms[number].idGame;
        info.GetCount();
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        if (GameInfoModel.playerCount != 4)
        {
            SceneManager.LoadScene(3);

        }
        
    }

    private Vector3 CanculatePosition(int i)
    {
        return new Vector3(i, i, 0);
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void GetAllRoom()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Rooms").LimitToLast(8).GetValueAsync()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    IsLoadDone = false;
                }
                else if (task.IsCompleted)
                {
                    int count = 0;
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    foreach (var room in snapshot.Children)
                    {
                        RoomInfo r = new RoomInfo();
                        r.idGame = room.Key.ToString();
                        r.number = ++count;
                        rooms.Add(r);
                       
                    }
                    IsLoadDone = true;
                }
            });

                                  //a.ContinueWith(task => {
        //    if (task.IsFaulted)
        //    {
        //        // Handle the error...
        //    }
        //    else if (task.IsCompleted)
        //    {
        //        DataSnapshot snapshot = task.Result;
        //       var b = snapshot.Children.ToString();
        //        Debug.Log(b);
        //        // Do something with snapshot...
        //    }
        //});

        //.ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
        //    if (e2.DatabaseError != null)
        //    {
        //      //  Debug.LogError(e2.DatabaseError.Message);
        //    }


        //    if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
        //    {

        //        foreach (var childSnapshot in e2.Snapshot.Children)
        //        {
        //            var name = childSnapshot.Child("name").Value.ToString();

        //        //    text.text = name.ToString();
        //            Debug.Log("Day la id room "+name.ToString());
        //             //text.text = childSnapshot.ToString();

        //         }

        //    }

        //  };
    }



    IEnumerator RenderRoom()
    {
        yield return new WaitWhile(() => IsLoadDone == false);
        int count = 0;
        foreach (var room in rooms)
        {
            count++;
            Debug.Log(room.idGame);
            GameObject roomGO = GameObject.Instantiate(roomprefaps) as GameObject;
            roomGO.transform.parent = canvas.transform;
         //   Debug.Log(roomGO.transform.position.x + "<-x  y->" + roomGO.transform.position.y);
            roomGO.transform.position = new Vector3(roomGO.transform.position.x + 3* count, transform.position.y);
        }
        canvas.active = true;
        Loading.active = false;

        //yield return new WaitWhile(() =>  info.isGetCountDone == false);
        
        //    GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("playercount").SetValueAsync(GameInfoModel.playerCount.ToString());
        //Debug.Log("Day la player count day len" + GameInfoModel.playerCount);
        //    info.isGetCountDone = false;
        
    }
    bool isRenderDone()
    {
       
        return true;
    }

}
