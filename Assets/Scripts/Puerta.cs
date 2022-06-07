using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puerta : MonoBehaviour
{
    [SerializeField] Text textoUi;
    [SerializeField] GameObject puerta;
    [SerializeField] GameObject pivote;
    private bool tieneLlave = false;
    private bool abierta = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if((tieneLlave)&&(abierta==false))
            {
                AbrirPuerta();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Llave")
        {
            textoUi.text = "Tienes la Llave para abrir la puerta pulsa E";
            tieneLlave = true;
        }
        else
        {
            textoUi.text = "Esta puerta esta cerrada, debe encontrar la llave escondida en esta sala";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Llave")
        {
            tieneLlave = false;
        }
    }
    private void AbrirPuerta()
    {
        puerta.gameObject.transform.RotateAround(pivote.transform.position, Vector3.up, 120);
    }

}
