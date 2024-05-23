using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointFirstLevelScene : MonoBehaviour
{
    [SerializeField] private ReadDataFromFile _readDataFromFile;
    [SerializeField] private CheckCorrectAnswer _checkCorrectAnswer;

    private void Start()
    {
        _readDataFromFile.Initialize();
        _checkCorrectAnswer.Initialize();
    }
}
