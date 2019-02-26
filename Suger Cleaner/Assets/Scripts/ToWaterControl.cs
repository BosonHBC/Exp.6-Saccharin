using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToWaterControl : MonoBehaviour
{

    [SerializeField] CleanerMovement movement;
    public bool bInWater;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!bInWater && other.transform.position.y < transform.GetChild(1).position.y)
            {
                bInWater = true;

            }
            else if (bInWater  && other.transform.position.y >= transform.GetChild(1).position.y)
            {
                bInWater = false;

            }
            GoInWater(bInWater);
        }

        if (other.CompareTag("Suger"))
        {
            Debug.Log("Exit");
            other.transform.parent.parent.gameObject.SetActive(false);
            GameManager.instance.Escape();
        }
    }

    void GoInWater(bool b_inWater)
    {
        PPController.instance.GoInWater(b_inWater);
        movement.GoToWater(b_inWater);
        GameManager.instance.PlayParticle();
    }
}
