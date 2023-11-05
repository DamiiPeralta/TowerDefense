using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CenterTextChanged : MonoBehaviour
{
    public GameObject thisObject;
    public TextMeshProUGUI centerText;
    public float timeTextInScreen;
    public bool textInScreen;
    void Start()
    {
        StartLevelText();
    }

    void Update()
    {
        if(textInScreen)
        {  
            timeTextInScreen -= Time.deltaTime;
            if(timeTextInScreen <= 0)
            {
                textInScreen = false;
                timeTextInScreen = 0f;
                thisObject.SetActive(false);


            }
        }
    }

    public void StartLevelText()
    {
        centerText.text = "START LEVEL!";
        textInScreen = true;
        timeTextInScreen = 3f;
    }
    //public void WaveNumberText(int wave)
    //{
    //    centerText.text = "WAVE " + wave;
    //    timeTextInScreen = 3f;
    //}
    public void EndLevelText()
    {
        centerText.text = "Level Succesfull!";
        timeTextInScreen = 3f;
        textInScreen = true;
    }

    public void YouLose()
    {
        Debug.Log("YouLose");
        centerText.text = "Level Failed!";
        timeTextInScreen = 3f;
        textInScreen = true;
    }
}
