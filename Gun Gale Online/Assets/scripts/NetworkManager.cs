using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomsList;
    public GameObject player;

    //public GameObject First_team;
   //public GameObject Second_team;
    public bool team=false; // false is team 1, true is team 2

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v4.2");
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
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                PhotonNetwork.CreateRoom(roomName, new RoomOptions()
                { MaxPlayers = 4, IsOpen = true, IsVisible = true }, lobbyName);
            }
            if (roomsList!=null)
            {
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
        Debug.Log("Connected to Room");

        PhotonNetwork.Instantiate(player.name, Vector3.up * 5, Quaternion.identity, 0);
    }
}
