using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiNPC : MonoBehaviour
{
    private float flDano;
    private float flVida;
    public Animator anZumbi;
    public Vector2 goJogadorUm;
    private Vector2 goBaseUm;
    private float flSpeed;


    void Start()
    {
        goBaseUm = GameObject.FindGameObjectWithTag("DefenseUm").gameObject.transform.position;
        flSpeed = 1f;
        flDano = 6.25f;
        flVida = 100f;

    }

    private void Update()
    {
        goJogadorUm = GameObject.FindGameObjectWithTag("Taeda").gameObject.transform.position;

        //validar se a distancia entre o npc e o player é menor que o npc e a base;
        if (GetComponent<Transform>().position.x < goBaseUm.x)
        {
            gameObject.transform.right = Vector2.left;
        }
        else
        {
            gameObject.transform.right = Vector2.right;
        }

        //valida a posicao do npc em relação ao jogador;
        if(GetComponent<Transform>().position.x < goJogadorUm.x)
        {
            gameObject.transform.right = Vector2.left;
        }
        else
        {
            gameObject.transform.right = Vector2.right;
        }
        
        

        //se movimenta em direção ao jogador
        if(!IrParaBase())
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(goJogadorUm.x, goJogadorUm.y), flSpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(goBaseUm.x, goBaseUm.y), flSpeed * Time.deltaTime);




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
