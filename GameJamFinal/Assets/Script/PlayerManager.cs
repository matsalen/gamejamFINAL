using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    #region Variaveis
    KeyCode voltar = KeyCode.Q;
    Vector3 offset;
    NavMeshAgent agent;
    [SerializeField] float x;
    [SerializeField] float z;
    [SerializeField] float freq_Hz = 30;
    [SerializeField] int maxFrame = 100;
    List<Vector3> posicoes = new List<Vector3>();
    List<Vector3> rbVelocity = new List<Vector3>();
    List<Vector3> rbAngularVelocity = new List<Vector3>();
    List<Quaternion> rotacoes = new List<Quaternion>();
    [Space(15)]
    public bool fixedupdate_50Hz = false;
    float freq;
    float cronometro;
    bool voltando = false;
    Rigidbody rb;
    #endregion

   



    void Start()
    {

       
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

    void ChecarVoltar()
    {
        if (!voltando)
        {
            posicoes.Add(transform.position);
            rotacoes.Add(transform.rotation);

            if (rb)
            {
                rbVelocity.Add(rb.velocity);
                rbAngularVelocity.Add(rb.angularVelocity);
            }

            if (posicoes.Count > maxFrame)
            {
                posicoes.Remove(posicoes[0]);
                rotacoes.Remove(rotacoes[0]);
                if (rb)
                {
                    rbVelocity.Remove(rbVelocity[0]);
                    rbAngularVelocity.Remove(rbAngularVelocity[0]);
                }
            }
        }
        else
        {
            if (posicoes.Count > 1)
            {
                posicoes.Remove(posicoes[posicoes.Count - 1]);
                rotacoes.Remove(rotacoes[rotacoes.Count - 1]);
                if (rb)
                {
                    rbVelocity.Remove(rbVelocity[rbVelocity.Count - 1]);
                    rbAngularVelocity.Remove(rbAngularVelocity[rbAngularVelocity.Count - 1]);
                }
            }
        }

    }
}
