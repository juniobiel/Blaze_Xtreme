using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorUm : MonoBehaviour
{
    //Movimentação do Personagem
    private float x, y, moduloVelocidade;
    public GameObject jogadorGrafico;
    private Animator animacaoJogador;
    public Rigidbody2D jogadorUm;
    //Propriedades do personagem
    private int vidaJogador, energiaJogador;

    //contador de tempo
    float contTimerEnergia = 0f;
    
    
    void Start()
    {
        vidaJogador = 100;
        energiaJogador = 0;
        animacaoJogador = jogadorGrafico.GetComponent<Animator>();
        jogadorUm = this.GetComponent<Rigidbody2D>();

        //Define o jogador Parado
        animacaoJogador.SetBool("esta-Parado", true);
    }

    // Update is called once per frame
    void Update()
    {
        //configurar barra de energia
        //barra de energia deve ser um elemento separado da barra de vida
        contTimerEnergia += Time.deltaTime;
        if(contTimerEnergia >= 5.0f)
        {
            energiaJogador++;
            if (energiaJogador > 3) energiaJogador = 3;
            contTimerEnergia = 0;
        }

        //Configs movimentação
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        moduloVelocidade = 2.0f;

        //Esta parado
        if (x == 0f && y == 0f)
        {
            animacaoJogador.SetBool("esta-Parado", true);
            animacaoJogador.SetBool("andar-Baixo", false);
            animacaoJogador.SetBool("andar-Cima", false);
            animacaoJogador.SetBool("andar-Esquerda", false);
            animacaoJogador.SetBool("andar-Direita", false);

            jogadorUm.velocity = new Vector2(0, 0);
        }
        //Andar pra Baixo
        else if (y < 0f)
        {
            if (x == 0)
            {
                animacaoJogador.SetBool("esta-Parado", false);
                animacaoJogador.SetBool("andar-Baixo", true);
                animacaoJogador.SetBool("andar-Cima", false);
                animacaoJogador.SetBool("andar-Esquerda", false);
                animacaoJogador.SetBool("andar-Direita", false);

                jogadorUm.velocity = new Vector2(x, y) * moduloVelocidade;
            }
        }
        //Andar pra Cima
        else if (y > 0f)
        {
            if (x == 0)
            {
                animacaoJogador.SetBool("esta-Parado", false);
                animacaoJogador.SetBool("andar-Cima", true);
                animacaoJogador.SetBool("andar-Baixo", false);
                animacaoJogador.SetBool("andar-Esquerda", false);
                animacaoJogador.SetBool("andar-Direita", false);

                jogadorUm.velocity = new Vector2(x, y) * moduloVelocidade;
            }
        }
        //Andar pra Esquerda
        if(x < 0f)
        {
            if (y == 0)
            {
                animacaoJogador.SetBool("esta-Parado", false);
                animacaoJogador.SetBool("andar-Esquerda", true);
                animacaoJogador.SetBool("andar-Baixo", false);
                animacaoJogador.SetBool("andar-Cima", false);
                animacaoJogador.SetBool("andar-Direita", false);

                jogadorUm.velocity = new Vector2(x, y) * moduloVelocidade;
                jogadorGrafico.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        //Andar pra Direita
        if(x > 0f)
        {
            if(y == 0)
            {
                animacaoJogador.SetBool("esta-Parado", false);
                animacaoJogador.SetBool("andar-Direita", true);
                animacaoJogador.SetBool("andar-Baixo", false);
                animacaoJogador.SetBool("andar-Cima", false);
                animacaoJogador.SetBool("andar-Esquerda", false);

                jogadorUm.velocity = new Vector2(x, y) * moduloVelocidade;
                jogadorGrafico.GetComponent<SpriteRenderer>().flipX = false;

            }
        }
    }
}
