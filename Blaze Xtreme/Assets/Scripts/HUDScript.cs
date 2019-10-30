using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text pontosJogadorUm;
    int pontosTotaisJogadorUm = 0;

    Image[] vidasJogadorUm;


    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }

    public void SetPontos(int points)
    {
        pontosJogadorUm = gameObject.GetComponentInChildren<Text>();
        pontosTotaisJogadorUm += points;
        pontosJogadorUm.text = pontosTotaisJogadorUm.ToString();
    }

    public int GetPontosJogadorUm()
    {
        return this.pontosTotaisJogadorUm;
    }
}
