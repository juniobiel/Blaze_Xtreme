using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taeda : MonoBehaviour
{
    private string nome;

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


    // ----------------------- Getters ----------------------------------

    public int GetIntVida()
    {
        return this.intVida;
    }
    public string GetNome()
    {
        return this.nome;
    }
    public float GetFlBarraHP()
    {
        return this.flBarraHP;
    }
    public float GetFlDanoHabilidadeUm()
    {
        return this.flDanoHabilidadeUm;
    }
    public Animator GetAnimatorTaeda()
    {
        return this.anAnimacaoTaeda;
    }
    public Rigidbody2D GetRGBDCorpoRigidoTaeda()
    {
        return this.rgbdControladorJogador;
    }
    

    // ----------------------- Métodos Principais -----------------------
    public void InstanciarPersonagem(string Nome)
    {
        this.nome = Nome;
        this.intVida = 3;
        this.flBarraHP = 1f;
        this.anAnimacaoTaeda = gameObject.GetComponent<Animator>();
        this.rgbdControladorJogador = gameObject.GetComponent<Rigidbody2D>();
        this.flDanoHabilidadeUm = 0.3725f;
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
