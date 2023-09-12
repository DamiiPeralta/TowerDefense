using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTowerToMouse : MonoBehaviour
{
    public GameObject towerPrefab;
    public MouseSelectedObject mouse;
    
    public void GetTower()
    {
        mouse.prefab = towerPrefab;
        mouse.SelectedTower(); 
    }
}
