using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieJuanAntonio : MonoBehaviour
{
    private GameObject[] ojos;
    [SerializeField] Animator animador;
    private NavMeshAgent agenteNav;
    private Vector3 posicionObjetivo;
    bool encontrado = false;
    GameObject jugadorEncontrado=null;
    public float distansia;
    Transform correccionTransform;


    private void Awake()
    {
        ojos = new GameObject[35];
        agenteNav = GetComponent<NavMeshAgent>();
        // arriba
        ojos[0] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.gameObject;
        ojos[1] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.gameObject;
        ojos[2] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.gameObject;
        ojos[3] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(3).transform.gameObject;
        ojos[4] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).transform.gameObject;
        ojos[5] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(5).transform.gameObject;
        ojos[6] = transform.GetChild(0).transform.GetChild(0).transform.GetChild(6).transform.gameObject;

        // frente

        ojos[7] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).transform.gameObject;
        ojos[8] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(1).transform.gameObject;
        ojos[9] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(2).transform.gameObject;
        ojos[10] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(3).transform.gameObject;
        ojos[11] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(4).transform.gameObject;
        ojos[12] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(5).transform.gameObject;
        ojos[13] = transform.GetChild(0).transform.GetChild(1).transform.GetChild(6).transform.gameObject;

        // abajo

        ojos[14] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.gameObject;
        ojos[15] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(1).transform.gameObject;
        ojos[16] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(2).transform.gameObject;
        ojos[17] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(3).transform.gameObject;
        ojos[18] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(4).transform.gameObject;
        ojos[19] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(5).transform.gameObject;
        ojos[20] = transform.GetChild(0).transform.GetChild(2).transform.GetChild(6).transform.gameObject;

    }

    private void FixedUpdate()
    {
        mirar();
        if (jugadorEncontrado!=null)
        {
            distansia = Vector3.Distance(this.transform.position, jugadorEncontrado.transform.position);
        }   
    }
    private void Update()
    {
        if(encontrado)
        {
            if (Vector3.Distance(this.transform.position,jugadorEncontrado.transform.position)<2.4)
            {
                animador.SetBool("Caminar", false);
                agenteNav.ResetPath();
                correccionTransform = jugadorEncontrado.transform;
                //correccionTransform.position += new Vector3(0f, -1.3f, 0f);
                //this.transform.LookAt(correccionTransform);
                animador.SetTrigger("Pegar");
            }
            else
            {
                Debug.Log("Voy a por el");
                agenteNav.SetDestination(jugadorEncontrado.transform.position);
                animador.SetBool("Caminar", true);
            }
        }
    }

    private void mirar()
    {
        for (int i = 0; i < 21; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(ojos[i].transform.position, ojos[i].transform.forward, out hit, 15))
            {
                if ((hit.transform.gameObject.tag=="Jugador")&&(encontrado==false))
                {
                    jugadorEncontrado = hit.transform.gameObject;
                    agenteNav.SetDestination(jugadorEncontrado.transform.position);
                    animador.SetBool("Caminar", false);
                    encontrado = true;
                    Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * hit.distance, Color.yellow);
                }
                else
                {
                    Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * hit.distance, Color.white);
                }
            }
            else
            {
                Debug.DrawRay(ojos[i].transform.position, ojos[i].transform.forward * 15, Color.white);
            }
        }
    }
    /*private void Perseguir()
    {
        Debug.Log("Voy a perseguir"); 
        animador.SetBool("Caminar", true);
        bool alcanzado = false;
        agenteNav.SetDestination(posicionObjetivo);
        while (alcanzado==false)
        {
            if (Vector3.Distance(posicionObjetivo, this.transform.position) < 1)
            {
                animador.SetBool("Pegar", true);
                yield return new WaitForSeconds(2f);
                animador.SetBool("Pegar", false);
            }
        }

    }*/
}
