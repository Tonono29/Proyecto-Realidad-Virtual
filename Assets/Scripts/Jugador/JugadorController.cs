using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    [SerializeField]private Slider vidas;
    public void QuitarVida()
    {
        vidas.value--;
        if (vidas.value==0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemigo")
        {
            QuitarVida();
        }
        else
        {
            Debug.Log("He colisionado con " + collision.gameObject.name);
        }
    }
}
