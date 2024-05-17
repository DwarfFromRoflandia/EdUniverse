using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string _region;
    [SerializeField] private TMP_InputField _cityNameInCreatedRoom;
    [SerializeField] private TMP_InputField _cityNameInJoinedRoom;

    [SerializeField] private TMP_InputField _passwordJoinedRoom;

    public void Intialize()
    {
        ConnectingToServer();
    }

    private void ConnectingToServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings(); //connecting to the server using file settings
            PhotonNetwork.GameVersion = "1"; //restriction on joining players with different versions to one room. In subsequent versions, more functionality may be added.
            PhotonNetwork.ConnectToRegion(_region); //connecting to the required region
            PhotonNetwork.EnableCloseConnection = true;
        }
    }

    private string GeneratePassword() => Random.Range(100000, 999999 + 1).ToString();

    public override void OnConnectedToMaster() //called when the client is connected to the Master Server and ready for matchmaking and other tasks.
    {
        Debug.Log($"connected to the region: {PhotonNetwork.CloudRegion}");

        if (!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();      
    }

    public override void OnDisconnected(DisconnectCause cause) //called after disconnecting from the Photon server. The reason for this disconnect is provided as DisconnectCause.
    {
        Debug.Log("the connection from the server is disconnected");
    }

    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected) return; // it will not be possible to create a room if the uder is not connected to Photon servers

        RoomOptions roomOptions = new RoomOptions(); //roomOptions wraps up common room properties needed when you create rooms.
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.NickName = _cityNameInCreatedRoom.text;

        PhotonNetwork.CreateRoom(GeneratePassword(), roomOptions, TypedLobby.Default); //creates a new room.When successful, this calls the callbacks OnCreatedRoom and OnJoinedRoom (the latter, cause you join as first player). Creating a room will fail if the room name is already in use. 

        PhotonNetwork.LoadLevel("TownScene"); //switching to another scene when CREATING a room
    }

    public override void OnCreatedRoom()
    {
        Debug.Log($"room {PhotonNetwork.CurrentRoom.Name} has been created");
    }

    public override void OnCreateRoomFailed(short returnCode, string message) //called when the server couldn't create a room. The most common cause to fail creating a room, is when a title relies on fixed room-names and the room already exists.
    {
        Debug.Log($"Failed to create a room. Perhaps the name of the room {PhotonNetwork.CurrentRoom.Name} already exists");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("TownScene"); //switching to another scene when JOINING a room
    }

    public void JoinButton()
    {
        PhotonNetwork.NickName = _cityNameInJoinedRoom.text;
        PhotonNetwork.JoinRoom(_passwordJoinedRoom.text);
    }
}
