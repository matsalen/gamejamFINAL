using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoController : Personagens
{

    GameObject player;
   


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

    }


    private void Update()
    {
        GotoNextPoint();
   



        if (Input.GetKeyDown(voltar))
        {
            if (posicoes.Count > 1 && rotacoes.Count > 1)
            {
                voltando = true;
                if (rb)
                {
                    rb.useGravity = false;
                }

            }



        }

        if (Input.GetKeyUp(voltar))
        {
            voltando = false;
            if (rb)
            {
                rb.useGravity = true;
                rb.velocity = rbVelocity[rbVelocity.Count - 1];
                rb.angularVelocity = rbAngularVelocity[rbAngularVelocity.Count - 1];
            }
            agent.destination = transform.position;

        }

        if (fixedupdate_50Hz == false)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= freq)
            {
                cronometro = 0;
                ChecarVoltar();
            }

        }

        if (voltando)
        {
            transform.position = Vector3.Lerp(transform.position, posicoes[posicoes.Count - 1], Time.deltaTime * 5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacoes[rotacoes.Count - 1], Time.deltaTime * 5f);


        }
    }

    void FixedUpdate()
    {
        if (fixedupdate_50Hz)
        {
            ChecarVoltar();
        }

        if (rb)
        {
            if (voltando)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    void GotoNextPoint()
    {

        agent.destination = player.transform.position;

    }
}
