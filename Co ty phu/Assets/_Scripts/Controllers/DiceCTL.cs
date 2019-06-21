using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCTL : MonoBehaviour
{
    private DiceModel diceModel;
    private void Start()
    {
        diceModel = GetComponent<DiceModel>();
        diceModel.Init();
    }
    public void PourDice()
    {
        diceModel.PourDice();

    }
    private void Update()
    {
        diceModel.DiceUpdate();
    }

    public bool IsPourDone()
    {
        return diceModel.IsPourDone();
    }
}
