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
    void Start()
    {
        StartLevelText();
    }

    public void StartLevelText()
    {
        centerText.text = "START LEVEL!";
    }
    public void WaveNumberText(int wave)
    {
        centerText.text = "WAVE " + wave;
    }
    public void EndLevelText()
    {
        centerText.text = "Level Succesfull!";
    }

    public void YouLose()
    {
        centerText.text = "Level Failed!";
    }
}
