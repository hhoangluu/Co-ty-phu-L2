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
                case EPlotColor.WHITE:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.WhitePlotMaterial;
                    break;
                case EPlotColor.VIOLET:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.VioletPlotMaterial;
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
                case EPlotColor.COLOR1:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color1;
                    break;
                case EPlotColor.COLOR2:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color2;
                    break;
                case EPlotColor.COLOR3:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color3;
                    break;
                case EPlotColor.COLOR4:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color4;
                    break;
                case EPlotColor.COLOR5:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color5;
                    break;
                case EPlotColor.COLOR6:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color6;
                    break;
                case EPlotColor.COLOR7:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color7;
                    break;
                case EPlotColor.COLOR8:
                    GetComponent<Renderer>().material = ResourcesCTL.Instance.Color8;
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
            return GetComponent<Renderer>().bounds.size.x;
        }
    }
    public float SIZEBig
    {
        get
        {
            return GetComponent<Renderer>().bounds.size.x;
        }
    }
    public float SIZEY
    {
        get
        {
            return GetComponent<Renderer>().bounds.size.y;
        }
    }

    private bool underPlayer;
    public bool UnderPlayer { get => underPlayer; set => underPlayer = value; }



    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            underPlayer = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            underPlayer = false;
        }
    }
}
