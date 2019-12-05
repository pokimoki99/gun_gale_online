using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score_board : MonoBehaviour
{
    public Text scoreboardtext;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       


        PhotonNetwork.player.NickName = "Boi21";


        scoreboardtext.text = PhotonNetwork.player.NickName + gm.scoretext;


    }
}
