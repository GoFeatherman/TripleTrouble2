using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionInferior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<ControladorJuego>().Recolocar();
    }
}
