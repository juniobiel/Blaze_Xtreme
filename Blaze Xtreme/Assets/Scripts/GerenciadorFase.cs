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

        nivel = 1;
        dificuldade = 0.2f;
        pontoBase = 15;

    }
    void FixedUpdate()
    {


        if(VerificaPontuacao(scriptHUD.GetPontosJogadorUm(), scriptHUD.GetPontosJogadorDois()) >= pontoBase)
        {
            AumentarDificuldade(nivel);
            StartCoroutine(LvlUpTime());
        }
    }

    // ------------------------------ Getters ------------------------------
    public int GetNivel()
    {
      return this.nivel;
    }

    // ------------------------------ Principais Métodos ------------------------------
    IEnumerator LvlUpTime()
    {
        GameObject.Find("HUD").GetComponent<HUDScript>().lvlUped.SetActive(true);
        yield return new WaitForSeconds(3);
        GameObject.Find("HUD").GetComponent<HUDScript>().lvlUped.SetActive(false);
    }

    void AumentarDificuldade(int nivel)
    {
        pontoBase += pontoBase + (int)(pontoBase * dificuldade);
        Debug.Log("Ponto Base " + pontoBase);
        controladorNPC.AtualizarTodosNPCs(0.005f, 0.025f);
        this.nivel = nivel++;

    }

    int VerificaPontuacao(int pontuacaoUm, int pontuacaoDois)
    {
        int pontuacaoTotais = pontuacaoUm + pontuacaoDois;
        return pontuacaoTotais;
    }
}
