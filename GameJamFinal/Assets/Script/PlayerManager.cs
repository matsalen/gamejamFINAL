using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    Vector3 offset;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
      
    {

        offset = Vector3.zero;
        agent = GetComponent<NavMeshAgent>();
        offset =  transform.position - Camera.main.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = transform.position - offset;
       // Camera.main.transform.rotation = transform.rotation ;

        if (Input.GetMouseButton(1))
        {
            RaycastHit ray;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray, 100))
                agent.destination = ray.point;
        }
    }
}
