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

    public Sprite[] molduraJogadorUm = new Sprite[5];
    public Sprite[] molduraJogadorDois = new Sprite[5];

    public GameObject lvlUped;

    private void Start()
    {
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();

        baseHPHUD = GameObject.Find("BaseHP").GetComponentsInChildren<Image>()[1];

        lvlUped.SetActive(false);
    }

    private void Update()
    {
        baseHPHUD.fillAmount = GameObject.FindGameObjectWithTag("DefenseUm").GetComponent<BaseScript>().GetFillAmount();
        VerificaHPPersonagemUm();
    }
    // ------------------------- Principais Métodos -------------------------
    public void ReduzirVida(int vida)
    {
        vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
        Destroy(vidasJogadorUm[vida].gameObject);
        //gameOver
    }
    public void VerificaHPPersonagemUm()
    {
        float hpPersonagem = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Taeda>().GetFlBarraHP();


        if (hpPersonagem >= 0.8)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorUm").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorUm[0];
        }
        else if (hpPersonagem >= 0.6f && hpPersonagem < 0.8f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorUm").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorUm[1];
        }
        else if (hpPersonagem >= 0.4f && hpPersonagem < 0.6f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorUm").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorUm[2];
        }
        else if (hpPersonagem >= 0.2f && hpPersonagem < 0.4f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorUm").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorUm[3];
        }
        else if (hpPersonagem < 0.2f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorUm").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorUm[4];
        }
    }

    //public void VerificaHPPersonagemDois()
    //{
    //    float hpPersonagem = GameObject.Find("Hoshigake").GetComponent<Hoshigake>().GetFlBarraHP();


    //    if (hpPersonagem >= 0.8)
    //    {
    //        SpriteRenderer molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<SpriteRenderer>();
    //        molduraJogador.sprite = molduraJogadorUm[0].sprite;
    //    }
    //    else if (hpPersonagem >= 0.6f && hpPersonagem < 0.8f)
    //    {
    //        SpriteRenderer molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<SpriteRenderer>();
    //        molduraJogador.sprite = molduraJogadorUm[1].sprite;
    //    }
    //    else if (hpPersonagem >= 0.4f && hpPersonagem < 0.6f)
    //    {
    //        SpriteRenderer molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<SpriteRenderer>();
    //        molduraJogador.sprite = molduraJogadorUm[2].sprite;
    //    }
    //    else if (hpPersonagem >= 0.2f && hpPersonagem < 0.4f)
    //    {
    //        SpriteRenderer molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<SpriteRenderer>();
    //        molduraJogador.sprite = molduraJogadorUm[3].sprite;
    //    }
    //    else if (hpPersonagem < 0.2f)
    //    {
    //        SpriteRenderer molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<SpriteRenderer>();
    //        molduraJogador.sprite = molduraJogadorUm[4].sprite;
    //    }
    //}
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
