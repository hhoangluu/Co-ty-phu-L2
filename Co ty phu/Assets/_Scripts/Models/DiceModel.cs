using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceModel: MonoBehaviour
{
    public void Start()
    {
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


    public void PourDiceOther()
    {
        Vector3 vt3D1 = new Vector3();
        Vector3 vt3D2 = new Vector3();
        pullDice(out vt3D1, out vt3D2);
        dice1.PourDice(vt3D1);
        dice2.PourDice(vt3D2);
    }


    public void pushDice(Vector3 vt3D1, Vector3 vt3D2)
    {
        RotateDice1 = new DiceInfo();
        RotateDice2 = new DiceInfo();
        RotateDice1.x = vt3D1.x;
        RotateDice1.y = vt3D1.y;
        RotateDice1.z = vt3D1.z;

        RotateDice2.x = vt3D2.x;
        RotateDice2.y = vt3D2.y;
        RotateDice2.z = vt3D2.z;


        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("dice1").SetRawJsonValueAsync(JsonUtility.ToJson(RotateDice1));
        GameInfoModel.mDatabaseRef.Child("Game").Child(GameInfoModel.IdGame).Child("dice2").SetRawJsonValueAsync(JsonUtility.ToJson(RotateDice2));

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
           dice1.Pour=  false;
           dice2.Pour = false;

        }
    }

    public bool IsPourDone()
    {
        return (dice1.IsPourDone() && dice2.IsPourDone());
    }
        
       

    
}
