using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomsList;
    public GameObject player;
    public bool team=false; // false is team 1, true is team 2
    Vector3 pos;
    int rng;
    //SpawnSpot1[] spawnSpots1;
    //SpawnSpot2[] spawnSpots2;
    public GameObject[] spawnSpots1;
    public GameObject[] spawnSpots2;

    public int playerNumber;

    public string name;
    private InputField input;
    bool nameset;



    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v4.2");
        spawnSpots1 = GameObject.FindGameObjectsWithTag("spawnpoints");
        spawnSpots2 = GameObject.FindGameObjectsWithTag("spawnpoints2");
        nameset=false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else if (PhotonNetwork.room==null)
        {
            name = GUI.TextField(new Rect(Screen.width / 2 - 300, Screen.height / 2, 100, 50), name);
            if (GUI.Button(new Rect(100, 100, 250, 100), "Enter Your Name"))
            {
                PhotonNetwork.player.NickName = name;
                nameset = true;
            }
            if (nameset==true)
            {
                if (GUI.Button(new Rect(300, 100, 250, 100), "Start Server"))
                {
                    PhotonNetwork.CreateRoom(roomName, new RoomOptions()
                    { MaxPlayers = 4, IsOpen = true, IsVisible = true }, lobbyName);
                }
            }

            if (roomsList!=null)
            {
                
                //PhotonNetwork.player.NickName = "playerUserNameHere";

                if (GUI.Button(new Rect(100, 300, 250, 100),
                    "Team 1"))
                {
                    team = false;
                    Debug.Log(team);
                }
                if (GUI.Button(new Rect(400, 300, 250, 100),
                    "Team 2"))
                {
                    team = true;
                    Debug.Log(team);
                }
                for (int i = 0; i < roomsList.Length; i++)
                {
                    if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100),
                            "Join" + roomsList[i].Name))
                    {
                        PhotonNetwork.JoinRoom(roomsList[i].Name);

                    }
                }
            }
        }
    }
    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(lobbyName);
    }
    void OnReceivedRoomListUpdate()
    {
        Debug.Log("Room Was Created");
        roomsList = PhotonNetwork.GetRoomList();
    }
    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }
    void OnJoinedRoom()
    {
        spawnplayer();
        Debug.Log("Connected to Room");

        }
    void spawnplayer()
    {
        if (team == false)
        {
            GameObject MyspawnSpots1 = spawnSpots1[Random.Range(0, spawnSpots1.Length)];
            pos = new Vector3(MyspawnSpots1.transform.position.x, MyspawnSpots1.transform.position.y + 0.4f, MyspawnSpots1.transform.position.z);
            player= PhotonNetwork.Instantiate("mc", pos, Quaternion.identity, 0);
        }


        if (team == true)
        {
            GameObject mySpawnSpot2 = spawnSpots2[Random.Range(0, spawnSpots2.Length)];
            pos = new Vector3(mySpawnSpot2.transform.position.x, mySpawnSpot2.transform.position.y + 0.4f, mySpawnSpot2.transform.position.z);
            player=PhotonNetwork.Instantiate("mc", pos, Quaternion.identity, 0);

        }
        playerNumber++;
    }
    public void GetInput(string name1)
    {
        Debug.Log(name1);
        input.text = "";
    }
}
