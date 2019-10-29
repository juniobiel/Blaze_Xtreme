using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorTelas : MonoBehaviour
{
   
    public void TelaStart()
    {
        float contTimer = 0f;
        contTimer += Time.deltaTime;
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
        SceneManager.LoadScene("SelecionarPersonagem", LoadSceneMode.Single);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }

    public void TelaMenuOptionControles()
    {
        SceneManager.LoadScene("Controles", LoadSceneMode.Single);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }
    public void TelaLoading()
    {
        float contTimer = 0f;
        contTimer += Time.deltaTime;
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
}
