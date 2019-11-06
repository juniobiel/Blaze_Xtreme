using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taeda : Personagem
{
    private string strNome;

    public Animator anAnimacaoTaeda;
    public Rigidbody2D rgbdControladorJogador;

    public Transform trHitBoxUm;
    public GameObject prefabHitBoxUm;
    public Transform trHitBoxEsquerda;
    public GameObject prefabHitBoxUmEsquerda;

    private bool blAttack = false;
    private float flDanoHabilidadeUm;

    private Image BarraHP;
    private float flBarraHP;
    private int intVida;

    // ---------------------- Setters -----------------------------------
    public void SetBlAttack(bool attack)
    {
        this.blAttack = attack;
    }
    public void SetFlBarraHP(float barraHP)
    {
        this.flBarraHP = barraHP;
    }
    public void SetIntVida(int vida)
    {
        this.intVida = vida;
    }
    public void SetFlDanoHabilidadeUm(float damage)
    {
        this.flDanoHabilidadeUm = damage;
    }


    // ----------------------- Getters ----------------------------------

    public int GetIntVida()
    {
        return this.intVida;
    }
    public string GetStrNome()
    {
        return this.strNome;
    }
    public bool GetBlAttack()
    {
        return this.blAttack;
    }
    public float GetFlBarraHP()
    {
        return this.flBarraHP;
    }
    public float GetFlDanoHabilidadeUm()
    {
        return this.flDanoHabilidadeUm;
    }
    public override Animator GetAnimatorPersonagem()
    {
        return this.anAnimacaoTaeda;
    }
    public override Rigidbody2D GetRGBDControladorJogador()
    {
        return this.rgbdControladorJogador;
    }
    

    // ----------------------- Métodos Principais -----------------------
    public void InstanciarPersonagem(string Nome)
    {
        this.strNome = Nome;
        this.intVida = 3;
        this.flBarraHP = 1f;
        this.flDanoHabilidadeUm = 0.3725f;
        this.anAnimacaoTaeda = gameObject.GetComponent<Animator>();
        this.rgbdControladorJogador = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnHitBox()
    {
        if (GameObject.FindGameObjectWithTag("Taeda").GetComponent<SpriteRenderer>().flipX == true)
        {
            GameObject hitEsquerda = Instantiate(prefabHitBoxUmEsquerda, trHitBoxEsquerda.position, trHitBoxEsquerda.localRotation);
            Destroy(hitEsquerda.gameObject, 0.5f);
        }
        else if (GameObject.FindGameObjectWithTag("Taeda").GetComponent<SpriteRenderer>().flipX == false)
        {
            GameObject hitDireita = Instantiate(prefabHitBoxUm, trHitBoxUm.position, trHitBoxUm.localRotation);
            Destroy(hitDireita.gameObject, 0.5f);
        }
    }

    public void FimDoAtaque()
    {
        this.blAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "inimigo":
                blAttack = false;
                float danoZumbi = GameObject.FindGameObjectWithTag("inimigo").GetComponent<ZumbiNPC>().GetFlDano();
                TomaDanoZumbi(danoZumbi);
                break;
        }
    }

    private void TomaDanoZumbi(float damage)
    {
        if(damage > flBarraHP)
        {
            if(intVida != 0)
            {
                intVida--;
                anAnimacaoTaeda.SetTrigger("perde-Vida");
                HUDScript BarraVida = GameObject.Find("HUD").GetComponent<HUDScript>();
                BarraVida.ReduzirVida(intVida);
                flBarraHP = 1.0f;
            }
            else
            {
                //game Over
            }
        }
        else if(flBarraHP >= damage)
        {
            flBarraHP -= damage;
            anAnimacaoTaeda.SetTrigger("toma-Hit");
        }

    }

    public void GetBarraHP()
    {
        BarraHP = GameObject.FindGameObjectWithTag("BarraHP").GetComponent<Image>();
        BarraHP.fillAmount = flBarraHP;
    }

}
