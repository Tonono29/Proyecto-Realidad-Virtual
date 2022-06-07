using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIgameover : MonoBehaviour
{
    public void Reintentar()
    {
        SceneManager.LoadScene("EscenaPrincipal");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
