using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public Text ammotext;
    public int ammocount = 500;

    public Player _score;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance = null;


    // Use this for initialization
    void Start()
    {
        _score.score = 0;
        UpdateScore();
    }

    // Update score text field
    public void UpdateScore()
    {
        scoretext.text = "Score: " + _score.score ;
        ammotext.text = "Ammo: " + ammocount;
    }

    // set the score
    public void setscore(int s)
    {
        _score.score = s;
        UpdateScore();
    }

    // increase the score
    public void incscore(int s)
    {
        _score.score = _score.score + s;

        
        UpdateScore();
    }

    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // fire
    public void fire()
    {
        ammocount--;
        UpdateScore();
    }

    // collect ammo
    public void collectammo()
    {
        ammocount += 10;
        if (ammocount > 100) ammocount = 100;
        UpdateScore();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            _score.score=1;
        }
        if (Input.GetKey(KeyCode.L))
        {
            _score.score=0;
        }
        if (Input.GetKey(KeyCode.J))
        {
            _score.score=2;
        }
        UpdateScore();
        if (_score.score == 10)
        {
            //gamewin
        }
    }
}
