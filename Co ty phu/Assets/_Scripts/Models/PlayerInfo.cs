using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{

    public int Money;
    public int Card;
    public int Position;
    public string color;
    public string Uid;

    public PlayerInfo()
    {
        Money = 200;
        Uid = PlayerModel.Uid;
        Position = 0;
    }

    
}
