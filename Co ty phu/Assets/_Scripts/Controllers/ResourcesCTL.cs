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
    private Material _redPlotMaterial;
    public Material RedPlotMaterial
    {
        get
        {
            if(_redPlotMaterial == null)
            {
                _redPlotMaterial = Resources.Load<Material>("Materials/RedPlot");//load material
            }
            return _redPlotMaterial;
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
    #endregion

}
