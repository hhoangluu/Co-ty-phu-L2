using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LobbyModel : MonoBehaviour
{
    public GameObject room;
    private GameInfoModel info;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject c = GameObject.Instantiate(room, CanculatePosition(1), Quaternion.identity) as GameObject;
        info = new GameInfoModel() ;
      //  info.Turn = 1;
        Debug.Log("Khoi tao info" + info);
        
    }

    public void writeNewGame()
    {
        //Debug.Log("Khoi tao info truoc khi chuyen " + info.Dice.Point);
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);

       var a =  GameInfoModel.mDatabaseRef.Push();
        GameInfoModel.IdGame = a.Key;
        a.SetRawJsonValueAsync(json);
        Debug.Log(GameInfoModel.IdGame+ " Day la id game");
    }

    public void EnterRoom()
    {
       
        string json = JsonUtility.ToJson(info);
        Debug.Log(json);
        SceneManager.LoadScene(3);
        
    }

    private Vector3 CanculatePosition(int i)
    {
        return new Vector3(i, i, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }


}
