using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPontos : MonoBehaviour
{
    public Text goTxtPontos;
    private int pontos = 0;

    public void SetPontos(int valorPontos)
    {
        this.pontos += valorPontos;
        goTxtPontos.text = pontos.ToString();
    }

    public int GetPontos()
    {
        return this.pontos;
    }
}
