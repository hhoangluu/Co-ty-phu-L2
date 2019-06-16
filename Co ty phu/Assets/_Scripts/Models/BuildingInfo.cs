using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BuildingInfo
{
    public int Level;
    public float Fees;
    public string Owner;
    public int Position;

    public BuildingInfo()
    {
        Level = 0;
        Fees = 0;
        Owner = "";
        Position = 0;
    }
}