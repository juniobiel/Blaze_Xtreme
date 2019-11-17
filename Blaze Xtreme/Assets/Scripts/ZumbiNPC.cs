using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZumbiNPC : MonoBehaviour
{
    private float flDano;
    private float flVida;
    private float flSpeed;

    public Animator anZumbi;
    public Vector2 goJogadorUm;
    public Vector2 goJogadorDois;
    private Vector2 goBaseUm;
    
    private Image BarraHP;

    HUDScript sptPontos;


    void Start()
    {
        goBaseUm = GameObject.FindGameObjectWithTag("DefenseUm").gameObject.GetComponent<PolygonCollider2D>().bounds.center;

        sptPontos = GameObject.Find("HUD").GetComponent<HUDScript>();

        SetFlVida(1.0f);
        SetFlDano(0.02f);
        SetFlSpeed(0.25f);

        SetZumbiHP(1f);
    }


    private void FixedUpdate()
    {
        GameObject HoshigakePlayer = GameObject.FindGameObjectWithTag("Hoshigake"); //esta perdendo as referencias ao setar inativo.
        GameObject TaedaPlayer = GameObject.FindGameObjectWithTag("Taeda"); //como resolver? **Usar variaveis estaticas.
        if (!TaedaPlayer.GetComponent<Taeda>().GetBlEstaMorto())
            goJogadorUm = TaedaPlayer.transform.position;
        else
            goJogadorUm = goBaseUm;

        if (!HoshigakePlayer.GetComponent<Hoshigake>().GetBlEstaMorto())
            goJogadorDois = HoshigakePlayer.transform.position;
        else
            goJogadorDois = goBaseUm;

        //se movimenta em direção ao jogador
        if (!IrParaBase())
        {
            float distanciaJogador, distanciaJogadorDois;
            
            distanciaJogador = Vector2.Distance(transform.position, goJogadorUm);
            distanciaJogadorDois = Vector2.Distance(transform.position, goJogadorDois);

            if(distanciaJogador < distanciaJogadorDois)
            {
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
            } else if( distanciaJogadorDois < distanciaJogador)
            {
                if (GetComponent<Transform>().position.x < goJogadorDois.x)
                {
                    gameObject.transform.right = Vector2.left;
                }
                else
                {
                    gameObject.transform.right = Vector2.right;
                }
                transform.position = Vector2.MoveTowards(transform.position,
                        new Vector2(goJogadorDois.x, goJogadorDois.y), flSpeed * Time.deltaTime);
            }

            
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
        float distanciaJogador, distanciaJogadorDois ,distanciaBase;
        distanciaJogador = Vector2.Distance(transform.position, goJogadorUm);
        distanciaJogadorDois = Vector2.Distance(transform.position, goJogadorDois);
        distanciaBase = Vector2.Distance(transform.position, goBaseUm);

        if (distanciaBase < distanciaJogador && distanciaBase < distanciaJogadorDois)
            return true;
        else if (distanciaBase > distanciaJogador || distanciaBase > distanciaJogadorDois)
            return false;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "hitBox1":
                float danoHabilidadeUmTaeda = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Taeda>().GetFlDanoHabilidadeUm();
                string strNome = GameObject.FindGameObjectWithTag("Taeda").GetComponent<Taeda>().GetStrNome();
                anZumbi.SetTrigger("toma-Hit");
                ZumbiTomaDano(danoHabilidadeUmTaeda, strNome);
            break;

            case "hitBoxHoshigake":
                float danoHabilidadeUmHoshigake = GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<Hoshigake>().GetFlDanoHabilidadeUm();
                string strNomeDois = GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<Hoshigake>().GetStrNome();
                anZumbi.SetTrigger("toma-Hit");
                ZumbiTomaDano(danoHabilidadeUmHoshigake, strNomeDois);
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

    public void ZumbiTomaDano(float damage, string Nome)
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
            List<GameObject> listaDeZumbi = GameObject.Find("ControladorNPCs").GetComponent<ControladorNPC>().GetListaZumbi();
            listaDeZumbi.Remove(gameObject);
            Destroy(gameObject);
            if (Nome == "Taeda")
                sptPontos.SetPontosJogadorUm(3);
            else
                sptPontos.SetPontosJogadorDois(3);
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
