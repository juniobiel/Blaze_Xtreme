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
    private int barraDeVida, vidaJogador, barraEnergia;

    //contador de tempo
    float contTimerEnergia = 0f;
    
    
    void Start()
    {
        animacaoJogador = jogadorGrafico.GetComponent<Animator>();
        jogadorUm = this.GetComponent<Rigidbody2D>();

        //Define o jogador Parado
        animacaoJogador.SetBool("esta-Parado", true);

        //Define atributos iniciais do personagem
        vidaJogador = 3;
        barraDeVida = 100;
        barraEnergia = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
        
        //configurar barra de energia
        //barra de energia deve ser um elemento separado da barra de vida
        contTimerEnergia += Time.deltaTime;
        if(contTimerEnergia >= 5.0f)
        {
            barraEnergia++;
            if (barraEnergia > 3) barraEnergia = 3;
            contTimerEnergia = 0;
        }

        //Configs movimentação
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        moduloVelocidade = 2.0f;

        //Esta parado
        if (x == 0f && y == 0f)
        {
            estaParado();
        }
        //Andar pra Baixo
        if (y < 0f)
        {
            andarPraBaixo();
        }
        //Andar pra Cima
        if (y > 0f)
        {
            andarPraCima();
        }
        //Andar pra Esquerda
        if(x < 0f)
        {
            andarPraEsquerda();   
        }
        //Andar pra Direita
        if(x > 0f)
        {
            andarPraDireita();
        }
    }

    void estaParado()
    {
        animacaoJogador.SetBool("esta-Parado", true);
        animacaoJogador.SetBool("andar-Baixo", false);
        animacaoJogador.SetBool("andar-Cima", false);
        animacaoJogador.SetBool("andar-Esquerda", false);
        animacaoJogador.SetBool("andar-Direita", false);

        jogadorUm.velocity = new Vector2(0, 0);
    }

    void andarPraBaixo()
    {
        if(x == 0)
            {
            animacaoJogador.SetBool("esta-Parado", false);
            animacaoJogador.SetBool("andar-Baixo", true);
            animacaoJogador.SetBool("andar-Cima", false);
            animacaoJogador.SetBool("andar-Esquerda", false);
            animacaoJogador.SetBool("andar-Direita", false);

            jogadorUm.velocity = new Vector2(x, y) * moduloVelocidade;
        }
    }

    void andarPraCima()
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

    void andarPraEsquerda()
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

    void andarPraDireita()
    {
        if (y == 0)
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
