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

    Image baseHPHUD;

    private void Start()
    {
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();

        baseHPHUD = GameObject.Find("BaseHP").GetComponentsInChildren<Image>()[1];
    }

    private void Update()
    {
        baseHPHUD.fillAmount = GameObject.FindGameObjectWithTag("DefenseUm").GetComponent<BaseScript>().GetFillAmount();
    }
    // ------------------------- Principais Métodos -------------------------
    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }
// ------------------------- Getters -------------------------

    public int GetPontosJogadorUm()
    {
        return this.pontosJogadorUm;
    }

    public int GetPontosJogadorDois()
    {
        return this.pontosJogadorDois;
    }

// ------------------------- Setters -------------------------
    public void SetPontosJogadorUm(int points)
    {
        Debug.Log("Esta recebendo " + points);
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        this.pontosJogadorUm += points;
        txtPontosJogadorUm.text = pontosJogadorUm.ToString();
    }

    public void SetPontosJogadorDois(int points)
    {
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();
        this.pontosJogadorDois += points;
        txtPontosJogadorDois.text = pontosJogadorDois.ToString();
    }
}
