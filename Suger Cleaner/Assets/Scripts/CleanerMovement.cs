using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerMovement : MonoBehaviour
{
    [SerializeField] private float fMovingForce;
    [SerializeField] private float fFloatForce;
    Rigidbody rb;
     bool bInWater;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
    }

    void PerformMovement()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hori, vert, 0);
        rb.AddForce(dir * fMovingForce * Time.fixedDeltaTime, ForceMode.Force);
        //rb.velocity = dir * fMovingForce * Time.deltaTime;
        if (bInWater)
            rb.AddForce(Vector3.up * fFloatForce * Time.fixedDeltaTime, ForceMode.Force);
    }

    public void GoToWater(bool b_Inwater)
    {
        bInWater = b_Inwater;
    }
}
