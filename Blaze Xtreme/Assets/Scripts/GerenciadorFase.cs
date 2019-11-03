using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFase : MonoBehaviour
{
    //ZumbiNPC scriptZumbi;  //perguntar sobre esta associação para a professora na aula de PROG
    HUDScript scriptHUD;
    ControladorNPC controladorNPC;

    int nivel;
    float dificuldade;
    int pontoBase;
    
    void Start()
    {
        scriptHUD = GameObject.Find("HUD").GetComponent<HUDScript>(); 
        controladorNPC = GameObject.Find("ControladorNPCs").GetComponent<ControladorNPC>();

        nivel = 0;
        dificuldade = 0.2f;
        pontoBase = 15;

    }
    void FixedUpdate()
    {
        
        Debug.Log("Pontuacao total: " + VerificaPontuacao(scriptHUD.GetPontosJogadorUm(), scriptHUD.GetPontosJogadorDois()) );
        if(VerificaPontuacao(scriptHUD.GetPontosJogadorUm(), scriptHUD.GetPontosJogadorDois()) >= pontoBase)
        {
            AumentarDificuldade(nivel);
            Debug.Log("Ficou mais dificil!");
        }
    }

    void AumentarDificuldade(int nivel)
    {
        pontoBase += pontoBase + (int)(pontoBase * dificuldade);
        Debug.Log("Ponto Base " + pontoBase);
        Debug.Log("Pontos do jogador Um: " + scriptHUD.GetPontosJogadorUm());
        Debug.Log("Pontos do jogador Dois: " + scriptHUD.GetPontosJogadorDois());
        controladorNPC.AtualizarTodosNPCs(0.01f, 0.05f);
        this.nivel = nivel++;

    }

    int VerificaPontuacao(int pontuacaoUm, int pontuacaoDois)
    {
        int pontuacaoTotais = pontuacaoUm + pontuacaoDois;
        return pontuacaoTotais;
    }
}
