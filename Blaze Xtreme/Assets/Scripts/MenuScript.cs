using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource musicaMenu;

    public void onClickJogar()
    {
        SceneManager.LoadScene("SelecionarPersonagem", LoadSceneMode.Single);
        DontDestroyOnLoad(musicaMenu);
    }

    public void onClickControles()
    {
        SceneManager.LoadScene("Controles", LoadSceneMode.Single);
        DontDestroyOnLoad(musicaMenu);
    }
}
