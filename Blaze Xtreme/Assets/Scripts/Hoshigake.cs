using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoshigake : MonoBehaviour
{
    public int vida;

    public class Movimentacao
    {
        public GameObject Hoshigake;
        public Animator animacaoJogador;
        public Rigidbody2D controladorJogador;
        public float moduloVelocidade = 2.0f;

        public Movimentacao(GameObject personagem, Animator animacaoJogador, Rigidbody2D controladorJogador)
        {
            this.Hoshigake = personagem;
            this.animacaoJogador = animacaoJogador;
            this.controladorJogador = controladorJogador;
        }

        public void EstaParado(float x, float y)
        {
            //Esta parado
            if (x == 0f && y == 0f)
            {
                animacaoJogador.SetBool("esta-Parado", true);
                animacaoJogador.SetBool("andar-Baixo", false);
                animacaoJogador.SetBool("andar-Cima", false);
                animacaoJogador.SetBool("andar-Esquerda", false);
                animacaoJogador.SetBool("andar-Direita", false);

                controladorJogador.velocity = new Vector2(0, 0);
            }
        }

        public void AndarPraBaixo(float x, float y)
        {
            //Andar pra Baixo
            if (y < 0f)
            {
                if (x == 0)
                {
                    animacaoJogador.SetBool("esta-Parado", false);
                    animacaoJogador.SetBool("andar-Baixo", true);
                    animacaoJogador.SetBool("andar-Cima", false);
                    animacaoJogador.SetBool("andar-Esquerda", false);
                    animacaoJogador.SetBool("andar-Direita", false);

                    controladorJogador.velocity = new Vector2(x, y) * moduloVelocidade;
                }
            }
        }

        public void AndarPraCima(float x, float y)
        {
            //Andar pra Cima
            if (y > 0f)
            {
                if (x == 0)
                {
                    animacaoJogador.SetBool("esta-Parado", false);
                    animacaoJogador.SetBool("andar-Cima", true);
                    animacaoJogador.SetBool("andar-Baixo", false);
                    animacaoJogador.SetBool("andar-Esquerda", false);
                    animacaoJogador.SetBool("andar-Direita", false);

                    controladorJogador.velocity = new Vector2(x, y) * moduloVelocidade;
                }
            }
        }

        public void AndarPraEsquerda(float x, float y)
        {
            //Andar pra Esquerda
            if (x < 0f)
            {
                if (y == 0)
                {
                    animacaoJogador.SetBool("esta-Parado", false);
                    animacaoJogador.SetBool("andar-Esquerda", true);
                    animacaoJogador.SetBool("andar-Baixo", false);
                    animacaoJogador.SetBool("andar-Cima", false);
                    animacaoJogador.SetBool("andar-Direita", false);

                    controladorJogador.velocity = new Vector2(x, y) * moduloVelocidade;
                    Hoshigake.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }

        public void AndarPraDireita(float x, float y)
        {
            //Andar pra Direita
            if (x > 0f)
            {
                if (y == 0)
                {
                    animacaoJogador.SetBool("esta-Parado", false);
                    animacaoJogador.SetBool("andar-Direita", true);
                    animacaoJogador.SetBool("andar-Baixo", false);
                    animacaoJogador.SetBool("andar-Cima", false);
                    animacaoJogador.SetBool("andar-Esquerda", false);

                    controladorJogador.velocity = new Vector2(x, y) * moduloVelocidade;
                    Hoshigake.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}
