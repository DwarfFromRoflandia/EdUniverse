using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private PlacementManager _placementManager;
    [SerializeField] private GameObject _roadStraight;
    [SerializeField] private RoadFixer _roadFixer;

    public List<Vector3Int> temporaryPlacementPositions = new List<Vector3Int>();
    public List<Vector3Int> roadPositionsToRecheck = new List<Vector3Int>();

    public void Initialize()
    {
        _roadFixer = GetComponent<RoadFixer>();
    }

    public void PlaceRoad(Vector3Int position)
    {
        if (_placementManager.CheckIfPositionInBound(position) == false)
            return;
        if (_placementManager.CheckIfPositionIsFree(position) == false)
            return;
        temporaryPlacementPositions.Clear();
        temporaryPlacementPositions.Add(position);
        _placementManager.PlaceTemporaryStructure(position, _roadStraight, CellType.Road);
        FixRoadPrefabs();
    }

    private void FixRoadPrefabs()
    {
        foreach (var temporaryPosition in temporaryPlacementPositions)
        {
            _roadFixer.FixRoadAtPosition(_placementManager, temporaryPosition);
            var neighbours = _placementManager.GetNeighboursOfTypeFor(temporaryPosition, CellType.Road);
            foreach (var roadposition in neighbours)
            {
                roadPositionsToRecheck.Add(roadposition);
            }
        }
        foreach (var positionToFix in roadPositionsToRecheck)
        {
            _roadFixer.FixRoadAtPosition(_placementManager, positionToFix);
        }
    }
}
