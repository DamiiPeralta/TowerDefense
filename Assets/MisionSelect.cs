using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionSelect : MonoBehaviour
{
    public StartLevel[] startLevel;

    private bool firstIncompleteLevelShown = false; // Variable para rastrear si ya se mostró el primer nivel no completado.

    public void SetInterfaz()
    {
        firstIncompleteLevelShown = false;
        for (int i = 0; i < startLevel.Length; i++)
        {
            if (startLevel[i].mision.win == false)
            {
                // Nivel no completado
                if (!firstIncompleteLevelShown)
                {
                    // Mostrar el primer nivel no completado sin aplicar SetImages
                    startLevel[i].gameObject.SetActive(true);
                    firstIncompleteLevelShown = true; // Marcar que se ha mostrado el primer nivel no completado
                }
                else
                {
                    // Ocultar niveles no completados posteriores
                    startLevel[i].gameObject.SetActive(false);
                }
            }
            else
            {
                // Nivel completado, Aplica SetImages en los completados
                startLevel[i].SetImages();
                startLevel[i].gameObject.SetActive(true);
            }
        }
    }
}
