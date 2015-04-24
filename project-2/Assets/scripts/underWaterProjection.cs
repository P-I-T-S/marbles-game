using UnityEngine;
using System.Collections;

public class underWaterProjection : MonoBehaviour {
    public float fps = 30.0f;
    public Texture2D[] frames;

    private int frameIndex = 0;
    private Projector waterprojector;

    void Start()
    {
        waterprojector = GetComponent<Projector>();
        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }

    void NextFrame()
    {
        waterprojector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }
}