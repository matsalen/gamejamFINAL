using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameController.instancia.CarregaJoia(this.tag.ToString());
            Destroy(this);
        }
    }

   
}
