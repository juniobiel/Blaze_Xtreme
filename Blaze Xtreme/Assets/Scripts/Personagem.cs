using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    private string strNome;
    private int intVida;
    private int intEnergia;
    
    public GameObject prefabPersonagem;
    public Animator anAnimacaoJogador;
    public Rigidbody2D rgbdControladorJogador;

    public Transform trHitBoxUm;
    public GameObject prefabHitBoxUm;
    public Transform trHitBoxEsquerda;
    public GameObject prefabHitBoxUmEsquerda;

    private Image BarraHP;
    private float flBarraHP;

    private bool blAttack = false;
    private float flDanoHabilidadeUm;

    public float GetFlDanoHabilidadeUm()
    {
        return this.flDanoHabilidadeUm;
    }

    public void SetBlAttack(bool attack)
    {
        this.blAttack = attack;
    }
    public bool GetBlAttack()
    {
        return this.blAttack;
    }

    public void SetStrNome(string nome)
    {
        this.strNome = nome;
    }

    public string GetStrNome()
    {
        return this.strNome;
    }

    public void SetIntVida(int vida)
    {
        this.intVida = vida;
    }

    public float GetFlBarraHP()
    {
        return this.flBarraHP;
    }

    public void SetFlBarraHP(float valorRetirado)
    {
        this.flBarraHP -= valorRetirado;
    }

    public void SetPrefabPersonagem(GameObject prefabPersonagem)
    {
        this.prefabPersonagem = prefabPersonagem;
    }

    public GameObject GetPrefabPersonagem()
    {
        return this.prefabPersonagem;
    }

    public int GetIntEnergia()
    {
        return this.intEnergia;
    }

    public void SetIntEnergia(int energia)
    {
        this.intEnergia = energia;
    }

    public void SetprefabHitBox(GameObject prefabHitBox)
    {
        this.prefabHitBoxUm = prefabHitBox;
    }

    public void SetgoHitBox(Transform goHitBox)
    {
        this.trHitBoxUm = goHitBox;
    }

    public Rigidbody2D GetRGBDControladorJogador()
    {
        return this.rgbdControladorJogador;
    }
    public void SetRGBDControladorJogador(Rigidbody2D rgbdControladorJogador)
    {
        this.rgbdControladorJogador = rgbdControladorJogador;
    }

    public void SetAnimatorPersonagem(Animator animacaoJogador)
    {
        this.anAnimacaoJogador = animacaoJogador;
    }

    public Animator GetAnimatorPersonagem()
    {
        return this.anAnimacaoJogador;
    }
    public void InstanciarPersonagem(string nome)
    {
        this.strNome = nome;
        this.intEnergia = 0;
        this.intVida = 3;
        this.flBarraHP = 1.0f;
        prefabPersonagem = gameObject;
        anAnimacaoJogador = this.gameObject.GetComponent<Animator>();
        rgbdControladorJogador = this.gameObject.GetComponent<Rigidbody2D>();
        flDanoHabilidadeUm = 0.1725f;
    }
    public void RecarregaEnergia()
    {
        if (intEnergia <= 3)
            intEnergia++;
    }

    public void OnHitBox()
    {
        if (GameObject.FindGameObjectWithTag("Taeda").GetComponent<SpriteRenderer>().flipX == true)
        {
            GameObject hitEsquerda = Instantiate(prefabHitBoxUmEsquerda, trHitBoxEsquerda.position, trHitBoxEsquerda.localRotation);
            Destroy(hitEsquerda.gameObject, 0.5f);
        }
        else if(GameObject.FindGameObjectWithTag("Taeda").GetComponent<SpriteRenderer>().flipX == false)
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
                this.anAnimacaoJogador.SetTrigger("toma-Hit");                
                TomaDanoZumbi(danoZumbi);
                break;
        }
    }

    private void TomaDanoZumbi(float damage)
    {
        this.flBarraHP -= damage;
        if (flBarraHP <= 0f)
        {
            if (intVida != 0) {
                intVida--;
                anAnimacaoJogador.SetTrigger("perder-Vida");
                flBarraHP = 1.0f;
                HUDScript BarraVida = GameObject.Find("HUD").GetComponent<HUDScript>();
                BarraVida.ReduzirVida(intVida);
                }
        }
        if (intVida == 0)
            Debug.Log("Game Over");
    }

    public void GetBarraHP()
    {
        BarraHP = GameObject.FindGameObjectWithTag("BarraHP").GetComponent<Image>();
        BarraHP.fillAmount = flBarraHP;
    }
}
