using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugerPart : MonoBehaviour
{
    FixedJoint fj;
    Rigidbody rb;
    bool bCanloose;
    Suger sugerParent;
    // Start is called before the first frame update
    void Start()
    {
        fj = GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
        sugerParent = transform.parent.parent.GetComponent<Suger>();
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
            rb.constraints = RigidbodyConstraints.None;
            int sign = Random.Range(0, 2);
            if (sign == 0)
                sign = -1;
            rb.AddForce(sign * sugerParent.transform.forward * 5f, ForceMode.Impulse);
            transform.SetParent(null);
            sugerParent.Loose();
            Destroy(fj);
            GameManager.instance.Clean();
        }

    }
}
