using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecionarPersonagemScript : MonoBehaviour
{
    public void onClickPersonagem()
    {
        SceneManager.LoadScene("BoxBase", LoadSceneMode.Single);
    }
    public void onClickVoltar()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        Destroy(GameObject.FindGameObjectWithTag("GerenciadorAudioMenu"));
    }
}
