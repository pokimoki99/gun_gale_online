using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class score_board : MonoBehaviour
{
    public Text scoreboardtext;
    public GameManager gm;
    public NetworkManager nick;

    GameObject scoreboard;
    int playerCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        playerCount = PhotonNetwork.playerList.Length;
        var playerNames = new StringBuilder();
        foreach (var player in PhotonNetwork.playerList)
        {
            scoreboardtext.text = nick.name + " " + gm.score + "\n" +playerNames.ToString();
            playerNames.Append(player.NickName + " " + gm.score1 + "\n");
            //string output = nick.name + playerCount.ToString() + "\n"
            //+ playerNames.ToString();
            //scoreboard.transform.Find("Text").GetComponent<Text>().text = playerCount.ToString();
        }
        //string output = nick.name + playerCount.ToString() + "\n"
        //    + playerNames.ToString();
        //scoreboard.transform.Find("Text").GetComponent<Text>().text = playerCount.ToString();


    }
    void UpdateScoreboard()
    {
        ////player count
        //playerCount = PhotonNetwork.playerList.Length;
        ////scoreboard text update
        //string output = nick.name + playerCount.ToString()
        //scoreboard.transform.Find("text").GetComponent<Text>().text = playerCount.ToString();
    }
}
