using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private EPlotColor _color;
    public EPlotColor Color
    {
        get { return _color; }
        set
        {
            _color = value;

            switch (_color)
            {
                case EPlotColor.RED:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.RedPlotMaterial;
                    break;
                case EPlotColor.GREEN:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.GreenPlotMaterial;
                    break;
                case EPlotColor.BLUE:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.BluePlotMaterial;
                    break;
                case EPlotColor.YELLOW:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.YellowPlotMaterial;
                    break;
                case EPlotColor.VIOLET:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.VioletPlotMaterial;
                    break;
                  
            }
        }
    }
    [ContextMenu("ChangePlotColor")]
    public void SetColor()
    {
        Color = EPlotColor.GREEN;
    }
    public float SIZEX
    {
        get
        {
          return  GetComponent<Renderer>().bounds.size.x;
        }
    }
    public float SIZEBig
    {
        get
        {
            return GetComponent<Renderer>().bounds.size.x;
        }
    }

   
}
