using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajesUI : MonoBehaviour
{
    [SerializeField]private Text textoui;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Jugador")
        {
            switch(this.name)
            {
                case "Bienvenida":
                    textoui.text = "Has conseguido abrir la celda, busca EL ARMA y la llave para acceder a la proxima sala";
                    break;
                case "PuertaCerrada":
                    textoui.text = "Esta puerta esta cerrada y no se puede abrir, encuentre la puerta correcta";
                    break;
                case "Cuidado":
                    textoui.text = "CUIDADO hay un enemigo, deberias tener ya un Arma y esta sala hay un escudo que te ayudara a defenderte";
                    break;
                default:
                    break;    
            }
        }
    }
}
