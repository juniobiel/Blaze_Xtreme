﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiNPC : MonoBehaviour
{
    private float flDano = 6.25f;
    private float flVida = 100f;
    public Animator anZumbi;
    public Vector2 goJogadorUm;
    private Vector2 goBaseUm;
    private float flSpeed = 0.775f;


    void Start()
    {
        goBaseUm = GameObject.FindGameObjectWithTag("DefenseUm").gameObject.transform.position;
    }

    private void Update()
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
                float danoHabilidadeUmTaeda = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Personagem>().GetFlDanoHabilidadeUm();
                ZumbiTomaDano(danoHabilidadeUmTaeda);
                if(flVida <= 0f)
                {
                    Destroy(this.gameObject);
                }
            break;
        }
    }

    public void ZumbiTomaDano(float damage)
    {
        this.flVida -= damage;
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
}
