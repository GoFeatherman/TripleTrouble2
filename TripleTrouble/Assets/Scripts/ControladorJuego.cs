using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;
    [SerializeField] private GameObject[] puntosDeControl;
    [SerializeField] private GameObject jugador;
    private int indexPuntosControl = 0;


    private void Awake()
    {
        Instance = this;
        if (indexPuntosControl >= puntosDeControl.Length)
        {
            PlayerPrefs.SetInt("puntosIndex", 0);
            indexPuntosControl = 0;
        }
        indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
        FindObjectOfType<ControladorJuego>().Recolocar();
    }

    public void UltimoPuntosControl(GameObject puntoControl)
    {
        for (int i = 0; i < puntosDeControl.Length; i++) 
        {
            if (puntosDeControl[i] == puntoControl && i > indexPuntosControl)
            {
                PlayerPrefs.SetInt("puntosIndex", i);
            }
        }
    }

    private void Update()
    {
    }

    public void Recolocar()
    {
        jugador.gameObject.transform.position = puntosDeControl[indexPuntosControl].transform.position;
    }
}
