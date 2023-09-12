using System;
using UnityEngine;

[Serializable]
public class Tower
{
    public string name;
    public int cost;

    public int stoneCost;

    public int woodCost;
    public GameObject prefab;

    public Tower(string _name, int _cost, int _stoneCost, int _woodCost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        stoneCost = _stoneCost;
        woodCost = _woodCost;
        prefab = _prefab;
    }
}
