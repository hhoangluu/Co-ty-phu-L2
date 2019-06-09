using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Dice;
    public GameObject Player;
  

    private DiceModel diceModel;
    private PlayerModel playerModel;

    void Start()
    {
     //   diceCTL = Dice.GetComponent<DiceCTL>();
     //   playerCTL = Player.GetComponent<PlayerCTL>();

        diceModel = Dice.GetComponent<DiceModel>();
        playerModel = Player.GetComponent<PlayerModel>();
        diceModel.Init();
        playerModel.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            diceModel.PourDice();
            
        }
        if (diceModel.IsPourDone() && !playerModel.IsMove)
        {
            Debug.Log("Bat dau di chuyen");
            playerModel.Move(diceModel.Point);
            
        }
        diceModel.DiceUpdate();
    }
}
