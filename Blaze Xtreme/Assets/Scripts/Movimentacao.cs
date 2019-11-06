using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    Taeda sptPersonagemUm;
    Hoshigake sptPersonagemDois;
    Personagem sptPersonagem;
    private float flModuloVelocidade;
    
    public Movimentacao() { }

    public void SetsptPersonagem(Taeda sptPersonagem)
    {
        this.sptPersonagemUm = sptPersonagem;
        this.sptPersonagem = sptPersonagemUm;
    }

    public void SetsptPersonagem(Hoshigake sptPersonagem)
    {
        this.sptPersonagemDois = sptPersonagem;
        this.sptPersonagem = sptPersonagemDois;
    }

    public float GetFlModuloVelocidade()
    {
        return this.flModuloVelocidade;
    }

    public void SetFlModuloVelocidade(float modulo)
    {
        this.flModuloVelocidade = modulo;
    }

    public void EstaParado(float x, float y)
    {
        //Esta parado
        if (x == 0f && y == 0f)
        {
            sptPersonagem.GetAnimatorPersonagem().SetBool("esta-Parado", true);
            sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Baixo", false);
            sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Cima", false);
            sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Esquerda", false);
            sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Direita", false);

            sptPersonagem.GetRGBDControladorJogador().velocity = new Vector2(0, 0);
        }
    }

    public void AndarPraBaixo(float x, float y)
    {
        //Andar pra Baixo
        if (y < 0f)
        {
            if (x == 0)
            {
                sptPersonagem.GetAnimatorPersonagem().SetBool("esta-Parado", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Baixo", true);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Cima", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Esquerda", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Direita", false);

                sptPersonagem.GetRGBDControladorJogador().velocity = new Vector2(x, y) * GetFlModuloVelocidade();
            }
        }
    }

    public void AndarPraCima(float x, float y)
    {
        //Andar pra Cima
        if (y > 0f)
        {
            if (x == 0)
            {
                sptPersonagem.GetAnimatorPersonagem().SetBool("esta-Parado", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Cima", true);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Baixo", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Esquerda", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Direita", false);

                sptPersonagem.GetRGBDControladorJogador().velocity = new Vector2(x, y) * GetFlModuloVelocidade();
            }
        }
    }

    public void AndarPraEsquerda(float x, float y)
    {
        //Andar pra Esquerda
        if (x < 0f)
        {
            if (y == 0)
            {
                sptPersonagem.GetAnimatorPersonagem().SetBool("esta-Parado", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Esquerda", true);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Baixo", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Cima", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Direita", false);

                sptPersonagem.GetRGBDControladorJogador().velocity = new Vector2(x, y) * GetFlModuloVelocidade();
                sptPersonagem.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public void AndarPraDireita(float x, float y)
    {
        //Andar pra Direita
        if (x > 0f)
        {
            if (y == 0)
            {
                sptPersonagem.GetAnimatorPersonagem().SetBool("esta-Parado", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Direita", true);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Baixo", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Cima", false);
                sptPersonagem.GetAnimatorPersonagem().SetBool("andar-Esquerda", false);

                sptPersonagem.GetRGBDControladorJogador().velocity = new Vector2(x, y) * GetFlModuloVelocidade();
                sptPersonagem.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
