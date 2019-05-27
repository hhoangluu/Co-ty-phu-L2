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
                    break;
                case EPlotColor.YELLOW:
                    break;
                default:
                    break;
            }
        }
    }
    [ContextMenu("ChangePlotColor")]
    public void SetColor()
    {
        Color = EPlotColor.GREEN;
    }
}
