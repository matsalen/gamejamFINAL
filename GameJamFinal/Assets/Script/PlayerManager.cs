﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : Personagens
{
    #region Variaveis
    Collider colPlayer;
    [SerializeField] float x;
    [SerializeField] float z;





    #endregion

   



    void Start()
    {
       
        colPlayer = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        freq = 1 / freq_Hz;
        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z) - new Vector3(x, 0, z);

        if (Input.GetMouseButton(1))
        {
            RaycastHit ray;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray, 100))
                agent.destination = ray.point;
        }
   
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

                colPlayer.enabled = false;
            Debug.Log(colPlayer.enabled);


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
            colPlayer.enabled = true; ;
            Debug.Log(colPlayer.enabled + "a");
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

}
