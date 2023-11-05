using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Data/Mision")]
public class Mision : ScriptableObject
{
    public int rewardCoins;

    public EnemieWave[] enemieWave;

    public bool win;


}
