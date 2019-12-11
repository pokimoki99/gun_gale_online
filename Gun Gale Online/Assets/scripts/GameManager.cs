using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public Text ammotext;
    public int ammocount = 500;
   
    public int score;
    public string gettingScore;
    public bool pistol, shotgun,sniper,crossbow, rifle = false;

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
        score = 0;
        UpdateScore();
        Screen.SetResolution(800, 600, false);
    }

    // Update score text field
    public void UpdateScore()
    {
        scoretext.text = "Score: " + score ;
        ammotext.text = "Ammo: " + ammocount;
    }

    // set the score
    public void setscore(int s)
    {
        score = s;
        UpdateScore();
    }
    public int getscore()
    {
        return score;
    }

    // increase the score
    public void incscore(int s)
    {
        score = score + s;

        
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
            score=1;
        }
        if (Input.GetKey(KeyCode.L))
        {
            score=0;
        }
        if (Input.GetKey(KeyCode.J))
        {
            score=2;
        }
        if (Input.GetKey(KeyCode.H))
        {
            score=3;
        }
        if (Input.GetKey(KeyCode.C))
        {
            score = 4;
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammocount = 0;
            Reload();
        }
        UpdateScore();
        Ammo();
        //if (ammocount<=0)
        //{
        //    Reload();
        //}
        if (score == 10)
        {
            //gamewin
        }
        gettingScore = score.ToString();
    }
    public void Ammo()
    {
        if (score==0)
        {
            if (pistol==false)
            {
                ammocount = 15;
                pistol = true;
            }
        }
        if (score==1)
        {
            if (shotgun==false)
            {
                ammocount = 28;
                shotgun = true;
            }
        }
        if (score==2)
        {
            if (rifle==false)
            {
                ammocount = 40;
                rifle = true;
            }
        }
        if (score == 3)
        {
            if (sniper == false)
            {
                ammocount = 2;
                sniper = true;
            }
        }
        if (score == 4)
        {
            if (crossbow == false)
            {
                ammocount = 2;
                crossbow = true;
            }
        }
    }
    public void Reload()
    {
        StartCoroutine(Reload_mechanic());
    }
    IEnumerator Reload_mechanic()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(1);
        pistol = true;
        shotgun = true;
        rifle = true;
        sniper = true;
        crossbow = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        pistol = false;
        shotgun = false;
        rifle = false;
        sniper = false;
        crossbow = false;
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
