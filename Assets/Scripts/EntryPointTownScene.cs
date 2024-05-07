using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointTownScene : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private RoadManager _roadManager;
    private void Start()
    {
        _gameManager.Initialize();
        _placementManager.Initialize();
        _roadManager.Initialize();
    }
}
