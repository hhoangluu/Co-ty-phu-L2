using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCTL
{
    private static ResourcesCTL _instance = null;
    public static ResourcesCTL Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ResourcesCTL();
            return _instance;
        }
    }

    #region thuộc tính

    private Material _whitePlotMaterial;
    public Material WhitePlotMaterial
    {
        get
        {
            if (_whitePlotMaterial == null)
            {
                _whitePlotMaterial = Resources.Load<Material>("Materials/WhitePlot");//load material
            }
            return _whitePlotMaterial;
        }
    }
    private Material _greenPlotMaterial;
    public Material GreenPlotMaterial
    {
        get
        {
            if (_greenPlotMaterial == null)
            {
                _greenPlotMaterial = Resources.Load<Material>("Materials/GreenPlot");//load material
            }
            return _greenPlotMaterial;
        }
    }

    private Material _bluePlotMaterial;
    public Material BluePlotMaterial
    {
        get
        {
            if (_bluePlotMaterial == null)
            {
                _bluePlotMaterial = Resources.Load<Material>("Materials/BluePlot");//load material
            }
            return _bluePlotMaterial;
        }
    }

    private Material _yellowPlotMaterial;
    public Material YellowPlotMaterial
    {
        get
        {
            if (_yellowPlotMaterial == null)
            {
                _yellowPlotMaterial = Resources.Load<Material>("Materials/YellowPlot");//load material
            }
            return _yellowPlotMaterial;
        }
    }
    private Material _violetPlotMaterial;
    public Material VioletPlotMaterial
    {
        get
        {
            if (_violetPlotMaterial == null)
            {
                _violetPlotMaterial = Resources.Load<Material>("Materials/VioletPlot");//load material
            }
            return _violetPlotMaterial;
        }
    }

    private Material _color1;
    public Material Color1
    {
        get
        {
            if (_color1 == null)
            {
                _color1 = Resources.Load<Material>("Materials/1-3");//load material
            }
            return _color1;
        }
    }

    private Material _color2;
    public Material Color2
    {
        get
        {
            if (_color2 == null)
            {
                _color2 = Resources.Load<Material>("Materials/5-6-7");//load material
            }
            return _color2;
        }
    }

    private Material _color3;
    public Material Color3
    {
        get
        {
            if (_color3 == null)
            {
                _color3 = Resources.Load<Material>("Materials/10-11");//load material
            }
            return _color3;
        }
    }
    private Material _color4;
    public Material Color4
    {
        get
        {
            if (_color4 == null)
            {
                _color4 = Resources.Load<Material>("Materials/13-15");//load material
            }
            return _color4;
        }
    }
    private Material _color5;
    public Material Color5
    {
        get
        {
            if (_color5 == null)
            {
                _color5 = Resources.Load<Material>("Materials/17-19");//load material
            }
            return _color5;
        }
    }
    private Material _color6;
    public Material Color6
    {
        get
        {
            if (_color6 == null)
            {
                _color6 = Resources.Load<Material>("Materials/21-22-23");//load material
            }
            return _color6;
        }
    }
    private Material _color7;
    public Material Color7
    {
        get
        {
            if (_color7 == null)
            {
                _color7 = Resources.Load<Material>("Materials/26-27");//load material
            }
            return _color7;
        }
    }
    private Material _color8;
    public Material Color8
    {
        get
        {
            if (_color8 == null)
            {
                _color8 = Resources.Load<Material>("Materials/29-31");//load material
            }
            return _color8;
        }
    }
    #endregion

}
