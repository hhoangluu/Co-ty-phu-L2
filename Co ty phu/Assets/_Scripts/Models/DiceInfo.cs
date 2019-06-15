using UnityEngine;

public class DiceInfo
{
    public SingleDiceInfo dice1;
    public SingleDiceInfo dice2;

    public DiceInfo()
    {
        dice1 = new SingleDiceInfo();
        dice2 = new SingleDiceInfo();
    }

    public string ToJson()
    {
        var json = "";
        json = "{\"dice1\":" + JsonUtility.ToJson(dice1) + ",\"dice2\":" + JsonUtility.ToJson(dice2) + "}";

        return json;

    }

}