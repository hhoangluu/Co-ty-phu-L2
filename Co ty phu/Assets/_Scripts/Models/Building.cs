using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseItem
{
    public int Level { get; set; }
    public int Fees { get; set; }
    public int Price { get; set; }
    public string Cityname { get; set; }
    public EPlayer Owner { get; set; }

    private void Init()
    {
    }

    private void Update()
    {
        
    }
}
