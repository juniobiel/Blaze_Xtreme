using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFase : MonoBehaviour
{
    //ZumbiNPC scriptZumbi;  //perguntar sobre esta associação para a professora na aula de PROG
    HUDScript scriptHUD;
    ControladorNPC controladorNPC;
    int contFase;
    int pontuacaoJogadorUm;
    int pontuacaoJogadorDois;
    int pontuacaoTotal;
    bool aumentou;
    void Start()
    {
        scriptHUD = GameObject.Find("HUD").GetComponent<HUDScript>();
        controladorNPC = GameObject.Find("ControladorNPCs").GetComponent<ControladorNPC>();
        contFase = 0;
        aumentou = false;

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            controladorNPC.AtualizarTodosNPCs(2f, 2f);
        //se aumentou é verdade e pontuacao igual ao nivel para aumentar, entao nao pode aumentar de novo
        //se o nv aumenta com tanto pontos, receber uma variável que se torna um multiplicador de pontos que deve
        //atingir para aumentar o nv.
        //if(int pontos == 15){
        //    AumentarDificuldade(contFase);
        //}
    }

    void AumentarDificuldade()
    {
        controladorNPC.AtualizarTodosNPCs(0.01f, 0.05f);
        contFase++;
        aumentou = true;
    }

    void VerificaPontuacao(int pontuacaoTotais)
    {

    }
}
