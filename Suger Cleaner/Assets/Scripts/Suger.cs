using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suger : MonoBehaviour
{
    Rigidbody mainRb;
    [SerializeField] float fFloatForce = 60;
    // Start is called before the first frame update
    void Start()
    {
        mainRb = transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mainRb.AddForce(Vector3.up * fFloatForce, ForceMode.Force);
    }
}
