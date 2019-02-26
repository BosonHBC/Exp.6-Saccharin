using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    SugerPart currentPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPart!=null)
            {
                currentPart.Loose();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Suger"))
        {
            Debug.Log(other.name + " Enter");
            currentPart = other.GetComponent<SugerPart>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Suger"))
        {
            Debug.Log(other.name + " Exit");
            currentPart = null;
        }
    }
}
