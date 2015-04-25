using UnityEngine;
using System.Collections;

public class underwatercameraeffect : MonoBehaviour
{

    //This script enables underwater effects. Attach to main camera.
    //Define variable
    public int underwaterLevel = 7;

    //The scene's default fog settings
    private bool defaultFog;
    private Color defaultFogColor;
    private float defaultFogDensity;
    private Material defaultSkybox;
    private Material noSkybox;

    void Start()
    {
        defaultFog = RenderSettings.fog;
        Color defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
        defaultSkybox = RenderSettings.skybox;

        //Set the background color
        GetComponent<Camera>().backgroundColor = new Color(0, 0.4f, 0.7f, 1);
        GameObject.FindGameObjectWithTag("Projector").GetComponent<Projector>().enabled = false;
    }

    void Update()
    {
        if (transform.position.y < underwaterLevel)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
            RenderSettings.fogDensity = 0.04f;
            RenderSettings.skybox = noSkybox;
            GameObject.FindGameObjectWithTag("Projector").GetComponent<Projector>().enabled = true;
        }
        else
        {
            RenderSettings.fog = defaultFog;
            RenderSettings.fogColor = defaultFogColor;
            RenderSettings.fogDensity = defaultFogDensity;
            RenderSettings.skybox = defaultSkybox;
            GameObject.FindGameObjectWithTag("Projector").GetComponent<Projector>().enabled = false;
        }
    }
}
