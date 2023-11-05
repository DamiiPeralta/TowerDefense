using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    public WaveController waveController;
    public Mision mision;
    public Image[] rewardCoinsImage;
    public GameObject misionPanel;

    public void SelectMision()
    {
        waveController.mision = mision;
        waveController.enemieWave = mision.enemieWave;
        waveController.StartWave();
        misionPanel.SetActive(false);
    }

    public void SetImages()
    {
        int misionRewardCoins = mision.rewardCoins;
        for(int i = 0; i < misionRewardCoins; i++)
        {
            Debug.Log(mision);
            Debug.Log("Moneda sumada");
            rewardCoinsImage[i].gameObject.SetActive(true);
        }
    }


}
