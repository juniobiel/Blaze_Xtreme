using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private string strNome;
    private int intVida;
    private int intEnergia;
    private float flBarraHP;
    public GameObject prefabPersonagem;
    public Animator anAnimacaoJogador;
    public Rigidbody2D rgbdControladorJogador;
    public Transform trHitBoxUm; //Habilidade
    public GameObject prefabHitBoxUm; //Habilidade
    private bool blAttack = false;


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
        this.flBarraHP = 100.0f;
        prefabPersonagem = gameObject;
        anAnimacaoJogador = gameObject.GetComponent<Animator>();
        rgbdControladorJogador = gameObject.GetComponent<Rigidbody2D>();
    }
    public void RecarregaEnergia()
    {
        if (intEnergia <= 3)
            intEnergia++;
    }

    public void OnHitBox()
    {
        GameObject hit = Instantiate(prefabHitBoxUm, trHitBoxUm);
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
                anAnimacaoJogador.SetTrigger("toma-hit");
                //ver aula em que o professor fez a barra de hp no slide
                flBarraHP -= gameObject.GetComponent<ZumbiNPC>().GetFlDano();
                break;
        }
    }
}
