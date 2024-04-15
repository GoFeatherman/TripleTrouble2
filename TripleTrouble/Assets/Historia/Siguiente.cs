using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Siguiente : MonoBehaviour
{
    public void jugar()
    {
        StartCoroutine("Esperar");
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.57f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
