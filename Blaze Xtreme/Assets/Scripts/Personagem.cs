using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    private string strNome;
    private int intVida;
    private int intEnergia;
    private float flBarraHP;
    private GameObject prefabPersonagem;
    private Animator anAnimacaoJogador;
    private Rigidbody2D rgbdControladorJogador;
    private Transform goHitBox;
    private GameObject prefabHitBox;

    public Personagem() { }
    public Personagem(string Nome)
    {
        this.strNome = Nome;
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
