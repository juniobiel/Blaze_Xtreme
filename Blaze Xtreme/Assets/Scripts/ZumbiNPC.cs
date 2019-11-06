using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZumbiNPC : MonoBehaviour
{
    private float flDano = 0.02f;
    private float flVida = 1.0f;
    private float flSpeed = 0.25f;

    public Animator anZumbi;
    public Vector2 goJogadorUm;
    private Vector2 goBaseUm;
    
    private Image BarraHP;

    HUDScript sptPontos;


    void Start()
    {
        goBaseUm = GameObject.FindGameObjectWithTag("DefenseUm").gameObject.transform.position;

        sptPontos = GameObject.Find("HUD").GetComponent<HUDScript>();

        SetZumbiHP(1f);
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
                float danoHabilidadeUmTaeda = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Taeda>().GetFlDanoHabilidadeUm();
                ZumbiTomaDano(danoHabilidadeUmTaeda);
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
        if (damage == flVida)
        {
            this.flVida = 0f;
            BarraHP.fillAmount = 0f;
        }
        else if (damage < flVida)
        {
            this.flVida -= damage;
            BarraHP.fillAmount = flVida;
        }
        else if(damage > flVida)
        {
            this.flVida = 0f;
            BarraHP.fillAmount = 0f;
            Destroy(gameObject);
            sptPontos.SetPontosJogadorUm(3);
        }
        else
            Debug.Log("Condição excessiva do método ZumbiTomaDano em ZumbiNPC");
           
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

    public void SetZumbiHP(float zumbiHP)
    {
        Image[] ElementosBarraHP = gameObject.GetComponentInChildren<Canvas>().GetComponentsInChildren<Image>();

        BarraHP = ElementosBarraHP[1];

        BarraHP.fillAmount = zumbiHP;
    }
}
