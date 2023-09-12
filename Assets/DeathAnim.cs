using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnim : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    private void Start() 
    {
        audioSource.Play();
        Destroy(gameObject, 5f);
    }
    
    
}
