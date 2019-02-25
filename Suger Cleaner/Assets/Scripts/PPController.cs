using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPController : MonoBehaviour
{
    public static PPController instance;

    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    PostProcessVolume volume;
    Bloom bloom;
    ColorGrading cg;
    private float[] boomIntensity = { 0.3f, 1.6f };
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out cg);

        if (bloom == null || cg == null)
            Debug.LogError("Effect not found");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoInWater(bool b_inWater)
    {
        bloom.active = true;
        bloom.intensity = new FloatParameter() { value = boomIntensity[b_inWater ? 1 : 0] };
        cg.active = b_inWater;


    }
}
