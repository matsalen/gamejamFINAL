using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmadilhaController : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    NavMeshAgent obs;


    void Start()
    {
        obs = GetComponent<NavMeshAgent>();

        obs.autoBraking = false;

        GotoNextPoint();
    }

    void Update()
    {

       // if (!obs.pathPending && obs.remainingDistance < 0.5f)
            GotoNextPoint();
    }
    void GotoNextPoint()
    {

        if (points.Length == 0)
            return;


        obs.destination = points[destPoint].position;


        destPoint = (destPoint + 1) % points.Length;
    }
}
