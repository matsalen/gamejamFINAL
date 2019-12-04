using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject botaoRecomecar, blur, joiaAzul, joiaVermelha, joiaRoxa;
    [SerializeField] Text textoTempo;
    [SerializeField] float tempoJogo;
    public static bool ativaVoltar;
    public static bool ativaAcelerar;
    public static bool ativaParar;



    #region Singleton
    public static GameController instancia;


    private void Awake()
    {
        if (instancia == null) instancia = this;
        else if (instancia != this) Destroy(this.gameObject);


    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        botaoRecomecar.SetActive(false);
        blur.SetActive(false);
        joiaAzul.SetActive(false);
        joiaVermelha.SetActive(false);
        joiaRoxa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempoJogo -= Time.deltaTime;
        textoTempo.text = Mathf.RoundToInt(tempoJogo).ToString();

        if (tempoJogo <= 0)
        {
            GameoverPal();
        }
    }

    void GameoverPal()
    {
        blur.SetActive(true);
        botaoRecomecar.SetActive(true);
        Time.timeScale = 0;
    }

    public void Recomecar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CarregaJoia(string cor)
    {
 
        if (cor == "joiaAzul")
        {
            ativaVoltar = true;
            joiaAzul.SetActive(true);
        }
        else joiaVermelha.SetActive(true);
        {
            ativaAcelerar = true;
        }

        if (joiaAzul.activeSelf && joiaVermelha.activeSelf)
        {
            joiaRoxa.SetActive(true);
            ativaParar = true;
        }
        
    }
}
