using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
    }

    [SerializeField] ParticleSystem bottomParticle;
    public GameObject player;
    [SerializeField] float fSqureLength;
    [SerializeField] GameObject EnemyPrefab;

    [SerializeField] Text cleanText;
    [SerializeField] Text excapeText;
    int cleaned;
    int escaped;
    
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("GenerateEnemy", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Clean()
    {
        cleaned++;
        cleanText.text = cleaned.ToString();
    }
    public void Escape()
    {
        escaped++;
        excapeText.text = escaped.ToString();
    }

    public void PlayParticle()
    {
        bottomParticle.Play();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fSqureLength);
    }

    Vector3 RandomPoint()
    {
        Vector3 _output;
        _output = Random.insideUnitCircle* fSqureLength ;
        return _output + transform.position;
    }

    void GenerateEnemy()
    {
        GameObject go = Instantiate(EnemyPrefab);
        go.transform.SetParent(transform);
        go.transform.localPosition = RandomPoint();
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, 0.4f, -1.16f);
        
    }
}
