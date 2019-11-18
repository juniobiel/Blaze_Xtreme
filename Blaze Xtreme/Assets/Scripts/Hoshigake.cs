using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hoshigake : Personagem
{
    private string strNome;

    public Animator anAnimacaoHoshigake;
    public Rigidbody2D rgbdControladorJogador;

    public Transform trHitBoxUm;
    public GameObject prefabHitBoxUm;
    public Transform trHitBoxEsquerda;
    public GameObject prefabHitBoxUmEsquerda;

    public bool blAttack = false;
    private float flDanoHabilidadeUm;

    private Image BarraHP;
    private float flBarraHP;
    private int intVida;

    private bool blEstaMorto;

    // ---------------------- Setters -----------------------------------
    public void SetBlEstaMorto(bool morreu)
    {
        this.blEstaMorto = morreu;
        gameObject.SetActive(false);
    }
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
    public bool GetBlEstaMorto()
    {
        return this.blEstaMorto;
    }
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
        return this.anAnimacaoHoshigake;
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
        this.anAnimacaoHoshigake = gameObject.GetComponent<Animator>();
        this.rgbdControladorJogador = gameObject.GetComponent<Rigidbody2D>();
        this.flDanoHabilidadeUm = 0.3725f;
        this.blEstaMorto = false;
    }
    //Habilidade
    public void OnHitBoxHoshigake()
    {
        if (GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<SpriteRenderer>().flipX == true)
        {
            GameObject hitEsquerda = Instantiate(prefabHitBoxUmEsquerda, trHitBoxEsquerda.position, trHitBoxEsquerda.localRotation);
            Destroy(hitEsquerda.gameObject, 0.5f);
        }
        else if (GameObject.FindGameObjectWithTag("Hoshigake").GetComponent<SpriteRenderer>().flipX == false)
        {
            GameObject hitDireita = Instantiate(prefabHitBoxUm, trHitBoxUm.position, trHitBoxUm.localRotation);
            Destroy(hitDireita.gameObject, 0.5f);
        }

    }
    public void FimDoAtaqueHoshigake()
    {
        SetBlAttack(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "inimigo":
                blAttack = false;
                float danoZumbi = col.gameObject.GetComponent<ZumbiNPC>().GetFlDano();
                if (intVida != 0)
                {
                    if (danoZumbi > flBarraHP)
                    {
                        intVida--;
                        anAnimacaoHoshigake.SetTrigger("perde-Vida");
                        HUDScript BarraVida = GameObject.Find("HUD").GetComponent<HUDScript>();
                        BarraVida.ReduzirVida(GetStrNome(),intVida);
                        flBarraHP = 1.0f;
                    }
                    else if (flBarraHP > danoZumbi)
                    {
                        flBarraHP -= danoZumbi;
                        anAnimacaoHoshigake.SetTrigger("toma-Hit");
                    }
                    else
                    {
                        flBarraHP -= danoZumbi;
                        anAnimacaoHoshigake.SetTrigger("toma-Hit");
                    }
                }

                else
                {
                    SetBlEstaMorto(true);
                }
                break;
        }
    }
    //fim habilidade

    public void GetBarraHP()
    {
        BarraHP = GameObject.FindGameObjectWithTag("BarraHPHoshigake").GetComponent<Image>();
        BarraHP.fillAmount = flBarraHP;
    }
}
