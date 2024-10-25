using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isplaceable;
    public bool Isplaceable { get { return isplaceable; } }

    void OnMouseDown()
    {
        if (isplaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isplaceable = !isPlaced;
        }
    }
}
