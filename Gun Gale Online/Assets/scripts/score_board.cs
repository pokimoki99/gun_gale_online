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
       


        //PhotonNetwork.player.NickName = ;


        //scoreboardtext.text = PhotonNetwork.player.NickName + gm.scoretext;
        scoreboardtext.text = nick.name + " " +gm.gettingScore;


    }
}
