using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text pontos;
    int pontosTotais = 0;

    Image[] vidasJogadorUm;


    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }

    public void SetPontos(int points)
    {
        pontos = gameObject.GetComponentInChildren<Text>();
        pontosTotais += points;
        pontos.text = pontosTotais.ToString();
    }
}
