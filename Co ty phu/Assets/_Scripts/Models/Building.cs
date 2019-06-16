using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseItem
{
    public int Level { get; set; }
    public float Fees { get; set; }
    public float Price { get; set; }
    public string Cityname { get; set; }
    public EPlayer Owner { get; set; }
    public int Position { get; set; }


    private void Init()
    {
    }

    private void Update()
    {

    }

    public Building(int pos)
    {
        Level = 0;
        Fees = 0;
        Price = 0; ;
        Cityname = "NoName";
        Owner = EPlayer.RED;
        Position = pos;
    }
}
