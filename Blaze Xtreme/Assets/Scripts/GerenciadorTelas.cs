using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorTelas : MonoBehaviour
{
    float contTimer = 0;
    void Update()
    {
        contTimer += Time.deltaTime;
        if(GameObject.FindGameObjectWithTag("TelaStart"))
            TelaStart(contTimer);
        if (GameObject.FindGameObjectWithTag("TelaLoading"))
            TelaLoading(contTimer);

    }

    public void TelaStart(float contTimer)
    {
        
        if (contTimer >= 4.0f)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Loading", LoadSceneMode.Single);
            }
        }
    }

    public void TelaSelecaoPersonagemOptionPersonagem()
    {
        SceneManager.LoadScene("Base1", LoadSceneMode.Single);
    }

    public void TelaMenuOptionJogar()
    {
        SceneManager.LoadScene("Base1", LoadSceneMode.Single);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }

    public void TelaMenuOptionControles()
    {
        SceneManager.LoadScene("Controles", LoadSceneMode.Single);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }
    public void TelaLoading(float contTimer)
    {
        if (contTimer >= 7.0f)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    public void BtnVoltarMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Destroy(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }
    public void BtnJogarNovamente()
    {
        SceneManager.LoadScene("Base1", LoadSceneMode.Single);
    }
}
