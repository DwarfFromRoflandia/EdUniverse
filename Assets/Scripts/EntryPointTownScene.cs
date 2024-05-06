using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointTownScene : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private void Start()
    {
        _gameManager.Initialize();
    }
}
