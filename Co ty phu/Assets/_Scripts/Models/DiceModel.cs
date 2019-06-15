using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceModel : MonoBehaviour
{
    public void Start()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("Game").Child(GameInfoModel.IdGame).Child("Dice")
       .ValueChanged += HandleValueChanged;
        Point = 0;
        IsDouble = false;
        Rotation = 0;
    }
    public DiceModel()
    {
        this.Point = 0;
        IsDouble = false;
        Rotation = 0;
    }
    public GameObject dice1GO;
    public GameObject dice2GO;
    private SingleDice dice1;
    private SingleDice dice2;
    public int Point
    {
        get; set;
    }
    bool isDouble;
    private int rotation;
    public bool IsDouble { get => isDouble; set => isDouble = value; }
    public int Rotation { get => rotation; set => rotation = value; }

    public Vector3 vt3Dice1;
    public Vector3 vt3Dice2;


    DiceInfo RotateDice1;
    DiceInfo RotateDice2;

    public void Init()
    {

        dice1 = dice1GO.GetComponent<SingleDice>();
        dice2 = dice2GO.GetComponent<SingleDice>();
    }

    public void pullDice(out Vector3 vt3D1, out Vector3 vt3D2)
    {
        vt3D1 = new Vector3(1, 2, 3);
        vt3D2 = new Vector3(1, 2, 3);
        // code....//

    }


    public void PourDiceOther(Vector3 vt3D1, Vector3 vt3D2)
    {
       
        dice1.PourDice(vt3D1);
        dice2.PourDice(vt3D2);
    }


    public void pushDice(Vector3 vt3D1, Vector3 vt3D2)
    {
        RotateDice1 = new DiceInfo();
     //   RotateDice2 = new DiceInfo();
        RotateDice1.dice1.x = vt3D1.x;
        RotateDice1.dice1.y = vt3D1.y;
        RotateDice1.dice1.z = vt3D1.z;

        RotateDice1.dice2.x = vt3D2.x;
        RotateDice1.dice2.y = vt3D2.y;
        RotateDice1.dice2.z = vt3D2.z;

        
        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("Dice").SetRawJsonValueAsync(JsonUtility.ToJson(RotateDice1));
        //GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("Dice").Child("dice2").SetRawJsonValueAsync(JsonUtility.ToJson(RotateDice2));

    }

    public void PourDice()
    {
        vt3Dice1 = new Vector3();
        vt3Dice2 = new Vector3();
        vt3Dice1 = dice1.PourDiceAgain();
        vt3Dice2 = dice2.PourDiceAgain();
        pushDice(vt3Dice1, vt3Dice2);
        dice1.PourDice(vt3Dice1);
        dice2.PourDice(vt3Dice2);
    }
    public void DiceUpdate()
    {
        dice1.CheckPoint();
        dice2.CheckPoint();
        if (dice1.IsPourDone() && dice2.IsPourDone())
        {
            Point = dice1.Point + dice2.Point;          //Điểm số của 2 xúc xắc
            //Point = 10;
        }
    }

    public void EndTurn()
    {
        if (dice1.IsPourDone() && dice2.IsPourDone())
        {
            dice1.Pour = false;
            dice2.Pour = false;

        }
    }

    public bool IsPourDone()
    {
        return (dice1.IsPourDone() && dice2.IsPourDone());
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {

        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;
        // neeus ddung turn thi moi gan du lieu
            Vector3 v1 = new Vector3();
        Vector3 v2 = new Vector3();
        v1.x = float.Parse(snapshot.Child("dice1").Child("x").Value.ToString());
        v1.y = float.Parse(snapshot.Child("dice1").Child("y").Value.ToString());
        v1.z = float.Parse(snapshot.Child("dice1").Child("z").Value.ToString());

        v2.x = float.Parse(snapshot.Child("dice2").Child("x").Value.ToString());
        v2.y = float.Parse(snapshot.Child("dice2").Child("y").Value.ToString());
        v2.z = float.Parse(snapshot.Child("dice2").Child("z").Value.ToString());
        Debug.Log("Lay dice x: " + v1.x +" y: " +v1.y );
        PourDiceOther(v1, v2);

    }
}
