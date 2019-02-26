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
    Camera cam;
    [SerializeField] LayerMask rayCastMask;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out cg);

        if (bloom == null || cg == null)
            Debug.LogError("Effect not found");
        cam = Camera.main;
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRaycast();

    }

    public void GoInWater(bool b_inWater)
    {
        bloom.active = true;
        bloom.intensity = new FloatParameter() { value = boomIntensity[b_inWater ? 1 : 0] };
        cg.active = b_inWater;


    }

    void CameraRaycast()
    {
        Vector2 mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;
        Ray ray = cam.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 200, Color.blue);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 10, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 150, rayCastMask))
        {
            Debug.DrawLine(player.transform.position, hit.point);
            player.GetComponent<CleanerMovement>().lookAtPoint = hit.point;
        }
    }
}
