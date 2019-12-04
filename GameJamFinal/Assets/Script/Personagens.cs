using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Personagens : MonoBehaviour
{
    #region variavel

   protected KeyCode voltar = KeyCode.Q;
   [SerializeField] protected  float freq_Hz = 30;
   [SerializeField] protected int maxFrame = 100;
    protected List<Vector3> posicoes = new List<Vector3>();
    protected List<Vector3> rbVelocity = new List<Vector3>();
    protected List<Vector3> rbAngularVelocity = new List<Vector3>();
    protected List<Quaternion> rotacoes = new List<Quaternion>();
    protected Rigidbody rb;
    [Space(15)]
    protected  bool fixedupdate_50Hz = false;
    protected float freq;
    protected float cronometro;
    public static bool voltando = false;
    protected NavMeshAgent agent;



    #endregion






   

    protected void ChecarVoltar()
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
