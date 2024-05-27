using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StructureModel : MonoBehaviour
{
    float yHeight = 0;

    public void CreateModel(GameObject model)
    {
        var structure = PhotonNetwork.Instantiate(model.name, gameObject.transform.position, Quaternion.identity);
        yHeight = structure.transform.position.y;
    }

    public void SwapModel(GameObject model, Quaternion rotation)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        var structure = PhotonNetwork.Instantiate(model.name, transform.position, Quaternion.identity);
        structure.transform.localPosition = new Vector3(0, yHeight, 0);
        structure.transform.localRotation = rotation;
    }
}
