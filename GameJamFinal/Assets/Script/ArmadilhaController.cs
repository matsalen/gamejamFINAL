using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmadilhaController : MonoBehaviour
{
    Vector3 posinicial;
    public Transform target;
    public float speed;
    bool Ativar = false;
    bool voltar = false;
    private void Start()
    {
        posinicial = transform.position;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        // trocar para quando pegar a bola
        if (Input.GetButton("Jump"))
            Ativar = true;
        // se a bola foi pega a armadilha vai ativar
        if (Ativar)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (transform.position == target.position)
            {
                voltar = true;
                Ativar = false;
            }
        }
        // se a armadilha ja ativou ela voltara e repetira a ativação
        if (voltar)
        {
            transform.position = Vector3.MoveTowards(transform.position, posinicial, step);
            if (transform.position == posinicial)
            {
                voltar = false;
                Ativar = true;
            }
        }
    }
}
