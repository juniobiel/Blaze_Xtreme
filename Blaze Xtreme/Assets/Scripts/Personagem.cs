using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public GameObject controladorPersonagem;
    public class Taeda : Personagem
    {
        public int energia = 3;
        public class HabilidadeUm : Taeda
        {
            public int damage = 7;
            public int energiaUsada = 1;
            public GameObject spritePoderHabilidadeUm;

            public void InvocarHabilidadeUm()
            {
                float posicaoX = controladorPersonagem.gameObject.transform.position.x;
                float posicaoY = controladorPersonagem.gameObject.transform.position.y;
                spritePoderHabilidadeUm = Instantiate(spritePoderHabilidadeUm, new Vector2(posicaoX + 1.0f, posicaoY)
                    , Quaternion.identity);
            }
        }

        public class HabilidadeDois : Taeda
        {
            public int damage = 12;
            public int energiaUsada = 2;
            public GameObject spritePoderHabilidadeDois;
        }

        public class HabilidadeTres : Taeda
        {
            public int damage = 17;
            public int energiaUsada = 3;
            public GameObject spritePoderHabilidadeTres;
        }

    }

    public class Movimentacao
    {
        public GameObject personagem;
        public Animator animacaoJogador;
        public Rigidbody2D controladorJogador;
        public float moduloVelocidade = 2.0f;

        public Movimentacao(GameObject personagem, Animator animacaoJogador, Rigidbody2D controladorJogador)
        {
            this.personagem = personagem;
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
                    personagem.GetComponent<SpriteRenderer>().flipX = true;
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
                    personagem.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}
