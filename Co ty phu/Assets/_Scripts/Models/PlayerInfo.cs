using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{

    public float Money;
    public int Card;
    public int Position;
    public string color;
    public string Uid;
    public int Countdown;
    public int Travel;
    public string username;

    public PlayerInfo()
    {
        Uid = LoginModel.userID;
        Position = 0;
        Travel = 0;
    }

}
