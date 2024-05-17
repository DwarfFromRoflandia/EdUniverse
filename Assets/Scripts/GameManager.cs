using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS;
using System;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private RoadManager _roadManager;

    public UIController uiController;

    public StructureManager structureManager;
    public void Initialize()
    {

        uiController.OnRoadPlacement += RoadPlacementHandler;
        uiController.OnHousePlacement += HousePlacementHandler;
        uiController.OnSpecialPlacement += SpecialPlacementHandler;
        uiController.OnBigStructurePlacement += BigStructurePlacementHandler;
        uiController.OnPlayerHousePlacement += PlayerHousePlacementHandler;
    }

    private void PlayerHousePlacementHandler()
    {
        ClearInputActions();
        _inputManager.OnMouseClick += structureManager.PlacePlayerHouseStructure;
    }

    private void BigStructurePlacementHandler()
    {
        ClearInputActions();
        _inputManager.OnMouseClick += structureManager.PlaceBigStructure;
    }

    private void SpecialPlacementHandler()
    {
        ClearInputActions();
        _inputManager.OnMouseClick += structureManager.PlaceSpecial;
    }

    private void HousePlacementHandler()
    {
        ClearInputActions();
        _inputManager.OnMouseClick += structureManager.PlaceHouse;
    }

    private void Update()
    {
        _cameraMovement.MoveCamera(new Vector3(_inputManager.CameraMovementVector.x, 0, _inputManager.CameraMovementVector.y));
    }

    private void RoadPlacementHandler()
    {
        ClearInputActions();

        _inputManager.OnMouseClick += _roadManager.PlaceRoad;
        _inputManager.OnMouseHold += _roadManager.PlaceRoad;
        _inputManager.OnMouseUp += _roadManager.FinishPlacingRoad;
    }

    private void ClearInputActions()
    {
        _inputManager.OnMouseClick = null;
        _inputManager.OnMouseHold = null;
        _inputManager.OnMouseUp = null;
    }

    public void LeaveButton()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("TownRegistrationScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) //notification of the nickname of the player who entered the room
    {
        Debug.LogFormat("Player {0} entered the room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) //notification of the nickname of the player who left the room
    {
        Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
    }
}
