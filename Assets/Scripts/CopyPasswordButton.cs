using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CopyPasswordButton : MonoBehaviour
{
    public void CopyNameRoom()
    {
        GUIUtility.systemCopyBuffer = PhotonNetwork.CurrentRoom.Name;
    }
}
