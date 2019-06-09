﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceModel: MonoBehaviour
{
    public GameObject dice1GO;
    public GameObject dice2GO;
    private SingleDice dice1;
    private SingleDice dice2;
    public int Point
    {
        get; set;
    }

    DiceModel()
    {

    }
    public void Init()
    {
        dice1 = dice1GO.GetComponent<SingleDice>();
        dice2 = dice2GO.GetComponent<SingleDice>();
    }
    public void PourDice()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dice1.Pour && !dice2.Pour)
            {

                dice1.PourDice();
                dice2.PourDice();
            }
            if (dice1.Pour && dice2.Pour)
            {

                dice1.PourDiceAgain();
                dice2.PourDiceAgain();
            }

        }
    }
    public void DiceUpdate()
    {
        dice1.CheckPoint();
        dice2.CheckPoint();
        if (dice1.IsPourDone() && dice2.IsPourDone())
        {
            Point = dice1.Point + dice2.Point;
        }
    }

    public bool IsPourDone()
    {
        return (dice1.IsPourDone() && dice2.IsPourDone());
    }
        
       

    
}
