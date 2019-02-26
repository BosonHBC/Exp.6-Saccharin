using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugerPart : MonoBehaviour
{
    FixedJoint fj;
    Rigidbody rb;
    bool bCanloose;
    // Start is called before the first frame update
    void Start()
    {
        fj = GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loose()
    {
        if (!bCanloose)
        {
            bCanloose = true;
            Debug.Log(transform.name + " Loose");
            tag = "Untagged";
            rb.useGravity = true;
            rb.AddForce(GameManager.instance.player.transform.forward * 20f, ForceMode.Force);
            transform.SetParent(null);
            Destroy(fj);
        }

    }
}
