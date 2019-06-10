﻿using System.Collections;
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

    private EPlayer turn;

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
        turn = EPlayer.RED;
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
       
        mapModel.ShowDeal();
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(1);
        Deal();
    }

    public void BuyBuilding()
    {
        mapModel.InitBuilding1(playerModel.Position);
        mapModel.hideDeal();
        
       // yield return new WaitForSeconds(1);
    }
}
