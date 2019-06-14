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

   
    public void Init()
    {
       
        dice1 = dice1GO.GetComponent<SingleDice>();
        dice2 = dice2GO.GetComponent<SingleDice>();
    }
    public void PourDice()
    {
        dice1.PourDiceAgain();
        dice2.PourDiceAgain();
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
