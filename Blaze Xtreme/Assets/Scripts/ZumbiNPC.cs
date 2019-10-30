using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZumbiNPC : MonoBehaviour
{
    private float flDano = 0.02f;
    private float flVida = 1.0f;
    public Animator anZumbi;
    public Vector2 goJogadorUm;
    private Vector2 goBaseUm;
    private float flSpeed = 0.25f;
    private Image BarraHP;


    void Start()
    {
        goBaseUm = GameObject.FindGameObjectWithTag("DefenseUm").gameObject.transform.position;
    }


    private void FixedUpdate()
    {
        goJogadorUm = GameObject.FindGameObjectWithTag("Taeda").gameObject.transform.position;

        //se movimenta em direção ao jogador
        if (!IrParaBase())
        {
            //valida a posicao do npc em relação ao jogador;
            if (GetComponent<Transform>().position.x < goJogadorUm.x)
            {
                gameObject.transform.right = Vector2.left;
            }
            else
            {
                gameObject.transform.right = Vector2.right;
            }
            transform.position = Vector2.MoveTowards(transform.position,
                    new Vector2(goJogadorUm.x, goJogadorUm.y), flSpeed * Time.deltaTime);
        }
        else
        {
            if (GetComponent<Transform>().position.x < goBaseUm.x)
            {
                gameObject.transform.right = Vector2.left;
            }
            else
            {
                gameObject.transform.right = Vector2.right;
            }
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(goBaseUm.x, goBaseUm.y), flSpeed * Time.deltaTime);
        }

        GetZumbiHP();
    }

    bool IrParaBase()
    {
        float distanciaJogador;
        float distanciaBase;
        distanciaJogador = Vector2.Distance(transform.position, goJogadorUm);
        distanciaBase = Vector2.Distance(transform.position, goBaseUm);

        if (distanciaBase < distanciaJogador)
            return true;
        else if (distanciaBase > distanciaJogador)
            return false;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "hitBox1":
                anZumbi.SetTrigger("toma-Hit");
                float danoHabilidadeUmTaeda = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Personagem>().GetFlDanoHabilidadeUm();
                ZumbiTomaDano(danoHabilidadeUmTaeda);
                if(flVida <= 0f)
                {
                    Destroy(this.gameObject);
                    HUDScript pontos = GameObject.Find("HUD").GetComponent<HUDScript>();
                    pontos.SetPontos(3);
                }
            break;
        }
    }

    public void SetFlSpeed(float velocidade)
    {
        this.flSpeed = velocidade;
    }

    public void SetFlDano(float dano)
    {
        this.flDano = dano;
    }

    public void ZumbiTomaDano(float damage)
    {
        this.flVida -= damage;
    }

    public float GetFlSpeed()
    {
        return this.flSpeed;
    }

    public Animator GetAnZumbi()
    {
        return this.anZumbi;
    }

    public float GetFlDano()
    {
        return this.flDano;
    }

    public float GetFlVida()
    {
        return this.flVida;
    }

    public void SetFlVida(float vida)
    {
        this.flVida -= vida;
    }

    public void GetZumbiHP()
    {
        Image[] ElementosBarraHP = gameObject.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>();

        BarraHP = ElementosBarraHP[1];

        BarraHP.fillAmount = flVida;
    }
}
