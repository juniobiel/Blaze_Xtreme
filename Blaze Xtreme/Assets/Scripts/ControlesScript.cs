using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlesScript : MonoBehaviour
{
    public void onClickVoltar()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
