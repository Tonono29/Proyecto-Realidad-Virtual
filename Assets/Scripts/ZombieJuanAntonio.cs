using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieJuanAntonio : MonoBehaviour
{
    private GameObject[] ojos;
    private bool encontrado;
    [SerializeField] Animator animador;
    private NavMeshAgent agenteNav;
    private Vector3 posicionObjetivo;
    bool persiguiendo = false;

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
    }

    private void mirar()
    {
        encontrado = false;

        for (int i = 0; i < 21; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(ojos[i].transform.position, ojos[i].transform.forward, out hit, 15))
            {
                if ((hit.transform.gameObject.tag == "Jugador")&&(encontrado==false))
                {
                    posicionObjetivo = hit.transform.position;
                    if (persiguiendo==false)
                    {
                        StartCoroutine("Perseguir");
                        persiguiendo = true;
                        encontrado = true;
                    }
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
    IEnumerator Perseguir()
    {
        Debug.Log("Voy a perseguir");
        animador.SetBool("Caminar", true);
        bool alcanzado = false;
        agenteNav.SetDestination(posicionObjetivo);
        while (alcanzado==false)
        {
            yield return new WaitForSeconds(1f);
            if (Vector3.Distance(posicionObjetivo, this.transform.position) < 1)
            {
                animador.SetBool("Pegar", true);
                yield return new WaitForSeconds(2f);
                animador.SetBool("Pegar", false);
            }
        }

    }
}
