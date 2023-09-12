using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float moveSpeed = 1f;
    public TextMeshProUGUI textObject;
    public GameObject targetObject;


    private void Start() 
    {
        targetObject = this.gameObject;
        Debug.Log(targetObject.transform.position);    
    }
    private void Update()
    {
        
        textObject.rectTransform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position);
        Move();
    }

    private void Move()
    {

        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    public void ChangeText(string text)
    {
        textObject.text = text;
    }
}
