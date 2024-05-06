using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private InputManager _inputManager;

    public void Initialize()
    {
        _inputManager.OnMouseClick += HandleMouseClick;

    }

    private void HandleMouseClick(Vector3Int position)
    {
        Debug.Log(position);
    }

    private void Update()
    {
        _cameraMovement.MoveCamera(new Vector3(_inputManager.CameraMovementVector.x, 0, _inputManager.CameraMovementVector.y));
    }
}
