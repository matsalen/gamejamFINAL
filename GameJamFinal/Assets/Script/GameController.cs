using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{




    #region Singleton
    public static GameController instancia;


    private void Awake()
    {
        if (this.gameObject == null) instancia = this;
        else if (instancia != null) Destroy(this.gameObject);


    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
