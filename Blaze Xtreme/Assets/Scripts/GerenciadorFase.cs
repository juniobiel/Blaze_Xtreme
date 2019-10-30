using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFase : MonoBehaviour
{
    ZumbiNPC scriptZumbi = GameObject.FindWithTag("inimigo").GetComponent<ZumbiNPC>(); //perguntar sobre esta associação para a professora na aula de PROG
    HUDScript scriptHUD = GameObject.Find("HUD").GetComponent<HUDScript>();
    void Start()
    {
        
    }
    void Update()
    {
        if(VerificaPontos() == 15)
        {
            AumentarDificuldade();
        }
    }

    void AumentarDificuldade()
    {
        float velocidade = scriptZumbi.GetFlSpeed();
        float dano = scriptZumbi.GetFlDano();

        dano += 0.005f;
        velocidade += 0.05f;

        scriptZumbi.SetFlSpeed(velocidade);
        scriptZumbi.SetFlDano(dano);
    }

    int VerificaPontos()
    {
        return scriptHUD.GetPontosJogadorUm();
    }
}
