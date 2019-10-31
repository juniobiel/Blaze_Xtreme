using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFase : MonoBehaviour
{
    //ZumbiNPC scriptZumbi;  //perguntar sobre esta associação para a professora na aula de PROG
    HUDScript scriptHUD;
    ControladorNPC controladorNPC;
    void Start()
    {
        //scriptZumbi = gameObject.AddComponent<ZumbiNPC>(); //arrumar essa de niveis e setar todos os 
        //damages pelo gerenciador
        scriptHUD = GameObject.Find("HUD").GetComponent<HUDScript>();
        controladorNPC = GameObject.Find("ControladorNPCs").GetComponent<ControladorNPC>();

        //Debug.Log(scriptZumbi.GetFlDano());
        //Debug.Log(scriptZumbi.GetFlSpeed());

        //scriptZumbi.SetFlDano(2f);
        //scriptZumbi.SetFlSpeed(2f);

       
        //Debug.Log(scriptZumbi.GetFlSpeed());

    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            controladorNPC.atualizarTodosNPCs(2f, 2f);
    }

    //void AumentarDificuldade()
    //{
    //    float velocidade = scriptZumbi.GetFlSpeed();
    //    float dano = scriptZumbi.GetFlDano();

    //    dano += 0.005f;
    //    velocidade += 0.05f;

    //    scriptZumbi.SetFlSpeed(velocidade);
    //    scriptZumbi.SetFlDano(dano);
    //    Debug.Log("Dificuldade aumentada!");
    //    Debug.Log(dano);
    //    Debug.Log(velocidade);
    //}

    //int VerificaPontos()
    //{
    //    return scriptHUD.GetPontosJogadorUm();
    //}
}
