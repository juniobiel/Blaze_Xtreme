using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text txtPontosJogadorUm;
    int pontosJogadorUm;

    Text txtPontosJogadorDois;
    int pontosJogadorDois;

    Image[] vidasJogadorUm;

    private void Start()
    {
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();
    }


    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }

    public void SetPontosJogadorUm(int points)
    {
        Debug.Log("Esta recebendo " + points);
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        this.pontosJogadorUm += points;
        txtPontosJogadorUm.text = pontosJogadorUm.ToString();
    }

    public int GetPontosJogadorUm()
    {
        return this.pontosJogadorUm;
    }
    public void SetPontosJogadorDois(int points)
    {
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();
        this.pontosJogadorDois += points;
        txtPontosJogadorDois.text = pontosJogadorDois.ToString();
    }

    public int GetPontosJogadorDois()
    {
        return this.pontosJogadorDois;
    }
}
