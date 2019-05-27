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
    #endregion 
    
}
