using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidade : MonoBehaviour
{
    Personagem sptPersonagem;
    private string strNome;
    private int dano;

    public Habilidade(Personagem sptPersonagem)
    {
        this.sptPersonagem = sptPersonagem;
    }

    public string GetStrNome()
    {
        return this.strNome;
    }

    public void SetStrNome(string strNome)
    {
        this.strNome = strNome;
    }

    void setDano(int dano)
    {
        this.dano = dano;
    }
    void ataqueDominacao()
    {
        sptPersonagem.GetAnimatorPersonagem().SetTrigger("habilidade-Um");
    }

    void gastarEnergia(int energia)
    {
        int energiaAtual = sptPersonagem.GetIntEnergia();
        energiaAtual -= energia;
        sptPersonagem.SetIntEnergia(energiaAtual);
    }
}
