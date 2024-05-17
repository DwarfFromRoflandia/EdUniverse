using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointTownRegistrationScene : MonoBehaviour
{
    [SerializeField] private PhotonManager _photonManager;

    private void Start()
    {
        _photonManager.Intialize();
    }
}
