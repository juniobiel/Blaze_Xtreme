using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text txtPontosJogadorUm;
    int pontosJogadorUm = 0;

    Text txtPontosJogadorDois;
    int pontosJogadorDois = 0;

    Image[] vidasJogadorUm;



    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }

    public void SetPontosJogadorUm(int points)
    {
        txtPontosJogadorUm = gameObject.GetComponentInChildren<Text>();
        pontosJogadorUm += points;
        txtPontosJogadorUm.text = pontosJogadorUm.ToString();
    }

    public int GetPontosJogadorUm()
    {
        return this.pontosJogadorUm;
    }
    public void SetPontosJogadorDois(int points)
    {
        txtPontosJogadorDois = gameObject.GetComponentInChildren<Text>();
        pontosJogadorDois += points;
        txtPontosJogadorUm.text = pontosJogadorDois.ToString();
    }

    public int GetPontosJogadorDois()
    {
        return this.pontosJogadorDois;
    }
}
