using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    Text txtPontosJogadorUm;
    public static int pontosJogadorUm;

    Text txtPontosJogadorDois;
    public static int pontosJogadorDois;

    Image[] vidasJogadorUm;
    Image[] vidasJogadorDois;

    Image baseHPHUD;

    public Sprite[] molduraJogadorUm = new Sprite[5];
    public Sprite[] molduraJogadorDois = new Sprite[5];

    public GameObject lvlUped;

    Taeda jogadorTaeda;
    Hoshigake jogadorHoshigake;

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
        VerificaGameOver();
    }
    // ------------------------- Principais Métodos -------------------------
    public void VerificaGameOver()
    {
        jogadorTaeda = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Taeda>();
        jogadorHoshigake = GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<Hoshigake>();

        if (jogadorTaeda.GetBlEstaMorto() && jogadorHoshigake.GetBlEstaMorto())
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

    }

    public void ReduzirVida(string Nome, int vida)
    {
        if (Nome == "Taeda")
        {
            vidasJogadorUm = GameObject.Find("VidasJogadorUm").GetComponentsInChildren<Image>();
            Destroy(vidasJogadorUm[vida].gameObject);
        }
        else if(Nome == "Hoshigake")
        {
            vidasJogadorDois = GameObject.Find("VidasJogadorDois").GetComponentsInChildren<Image>();
            Destroy(vidasJogadorDois[vida].gameObject);
        }
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

    public void VerificaHPPersonagemDois()
    {
        float hpPersonagem = GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<Hoshigake>().GetFlBarraHP();


        if (hpPersonagem >= 0.8)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorDois[0];
        }
        else if (hpPersonagem >= 0.6f && hpPersonagem < 0.8f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorDois[1];
        }
        else if (hpPersonagem >= 0.4f && hpPersonagem < 0.6f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorDois[2];
        }
        else if (hpPersonagem >= 0.2f && hpPersonagem < 0.4f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorDois[3];
        }
        else if (hpPersonagem < 0.2f)
        {
            Image molduraJogador = GameObject.Find("PontosJogadorDois").GetComponent<Image>();
            molduraJogador.sprite = molduraJogadorDois[4];
        }
    }

    // ------------------------- Getters -------------------------

    public int GetPontosJogadorUm()
    {
        return HUDScript.pontosJogadorUm;
    }

    public int GetPontosJogadorDois()
    {
        return HUDScript.pontosJogadorDois;
    }

// ------------------------- Setters -------------------------
    public void SetPontosJogadorUm(int points)
    {
        Debug.Log("Esta recebendo " + points);
        txtPontosJogadorUm = GameObject.Find("PontosJogadorUm").GetComponentInChildren<Text>();
        HUDScript.pontosJogadorUm += points;
        txtPontosJogadorUm.text = pontosJogadorUm.ToString();
    }

    public void SetPontosJogadorDois(int points)
    {
        txtPontosJogadorDois = GameObject.Find("PontosJogadorDois").GetComponentInChildren<Text>();
        HUDScript.pontosJogadorDois += points;
        txtPontosJogadorDois.text = pontosJogadorDois.ToString();
    }
}
