using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suger : MonoBehaviour
{
    Rigidbody mainRb;
    [SerializeField] float fFloatForce = 60;
    int bodyAmount;
    bool bDead;
    // Start is called before the first frame update
    void Start()
    {
        mainRb = transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>();
        bodyAmount = 3;
    }
    public void Loose()
    {
        bodyAmount--;
        if(bodyAmount == 0)
        {
            bDead = true;
            mainRb.useGravity = true;
            int sign = Random.Range(0, 2);
            if (sign == 0)
                sign = -1;
            mainRb.constraints = RigidbodyConstraints.None;
            mainRb.AddForce(sign * transform.forward * 5f, ForceMode.Impulse);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(mainRb && !bDead)
        mainRb.AddForce(Vector3.up * fFloatForce, ForceMode.Force);
    }
}
