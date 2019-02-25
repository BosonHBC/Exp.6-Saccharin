using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    [SerializeField] ParticleSystem bottomParticle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayParticle()
    {
        bottomParticle.Play();

    }
}
