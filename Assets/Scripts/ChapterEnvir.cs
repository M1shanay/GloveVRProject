using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Rendering;

public class ChapterEnvir : MonoBehaviour
{
    public LightingSettings lightingSettings;
    public LightingDataAsset lightingDataAsset;
    public Material Skybox;

    public bool Fog;
    public Color32 FogColor;
    public float FogDensity;

    public Color32 SkyColor;
    public Color32 EquatorColor;
    public Color32 GroundColor;
    public bool SkyColorSourceGradient;
    public bool SkyColorSourceColor;

    void Start()
    {
        
    }
    public void SetEvirLightning()
    {
        //Lightmapping.lightingSettings = lightingSettings;
        Lightmapping.lightingDataAsset = lightingDataAsset;
        RenderSettings.skybox = Skybox;

        if (SkyColorSourceColor)
        {
            RenderSettings.ambientMode = AmbientMode.Flat;
            RenderSettings.ambientSkyColor = SkyColor;
        }

        if(Fog)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = FogColor;
            RenderSettings.fogDensity = FogDensity;
        }
        if(!Fog)
        {
            RenderSettings.fog = false; 
        }
    }
    public void ActivateEnvironment()
    {
        gameObject.SetActive(true);
        SetEvirLightning();
    }
    public void DeactivateEnvironment()
    {
        gameObject.SetActive(false);
    }
}
