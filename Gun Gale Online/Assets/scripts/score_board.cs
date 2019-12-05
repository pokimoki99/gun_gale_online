using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score_board : MonoBehaviour
{
    public Text scoreboardtext;
    public GameManager gm;
    public NetworkManager nick;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

       //for(int i=0; nick.playerNumber==i ;i++)
        scoreboardtext.text = nick.name + " " +gm.gettingScore;
        //Debug.Log("testing scoreboard");


    }
}
