using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personagem;

public class ControladorJogadorUm : MonoBehaviour
{
    public GameObject personagem;
    public Animator animacaoJogador;
    public Rigidbody2D controladorJogador;
    public Movimentacao movimentacao;
    public float x;
    public float y;
    //Movimentação do Personagem
    
    
    void Start()
    {
        movimentacao = new Movimentacao(personagem, animacaoJogador, controladorJogador);
        //Define o jogador Parado
        movimentacao.animacaoJogador.SetBool("esta-Parado", true);
      


    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        movimentacao.EstaParado(x, y);
        movimentacao.AndarPraBaixo(x, y);
        movimentacao.AndarPraCima(x, y);
        movimentacao.AndarPraEsquerda(x, y);
        movimentacao.AndarPraDireita(x, y);






        //if (Input.GetButtonDown("AZUL0"))
        //{
        //    animacaoJogador.SetTrigger("habilidade-Um");
        //}

        ////configurar barra de energia
        ////barra de energia deve ser um elemento separado da barra de vida
        //contTimerEnergia += Time.deltaTime;
        //if (contTimerEnergia >= 5.0f)
        //{
        //    barraEnergia++;
        //    if (barraEnergia > 3) barraEnergia = 3;
        //    contTimerEnergia = 0;
        //}

        //Configs movimentação
        //x = Input.GetAxis("HORIZONTAL0");
        //y = Input.GetAxis("VERTICAL0");
        //moduloVelocidade = 2.0f;

    }
}
