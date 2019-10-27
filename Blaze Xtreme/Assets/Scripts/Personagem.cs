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
    private Transform goHitBox; //Habilidade
    private GameObject prefabHitBox; //Habilidade

    private void Start()
    {
        InstanciarPersonagem("Taeda");
    }
    public void InstanciarPersonagem(string nome)
    {
        this.strNome = nome;
        this.intEnergia = 0;
        this.intVida = 3;
        this.flBarraHP = 100.0f;
    }

    public void SetStrNome(string nome)
    {
        this.strNome = nome;
    }

    public string GetStrNome()
    {
        return this.strNome;
    }

    public void RecarregaEnergia()
    {
        float contTimer = 0f;

        contTimer += Time.deltaTime;
        if(contTimer >= 6.0f)
        {
            if (intEnergia <= 3)
                intEnergia++;
            contTimer -= contTimer;
        }
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
        this.prefabHitBox = prefabHitBox;
    }

    public void SetgoHitBox(Transform goHitBox)
    {
        this.goHitBox = goHitBox;
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
}
