using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiedraMagica : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerPrefs.DeleteKey("puntosIndex");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
