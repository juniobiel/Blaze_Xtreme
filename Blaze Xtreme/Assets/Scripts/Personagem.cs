using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    private string strNome;
    private int intVida;
    private int intEnergia;
    private Animator anAnimacaoJogador;
    private Rigidbody2D rgbdControladorJogador;
    private Transform goHitBox;
    private GameObject prefabHitBox;

    public Personagem() { }
    public Personagem(string Nome)
    {
        this.strNome = Nome;
    }

    

    public int getIntEnergia()
    {
        return this.intEnergia;
    }

    public void setIntEnergia(int energia)
    {
        this.intEnergia = energia;
    }

    public void setprefabHitBox(GameObject prefabHitBox)
    {
        this.prefabHitBox = prefabHitBox;
    }

    public void setgoHitBox(Transform goHitBox)
    {
        this.goHitBox = goHitBox;
    }

    public void setRGBDControladorJogador(Rigidbody2D rgbdControladorJogador)
    {
        this.rgbdControladorJogador = rgbdControladorJogador;
    }

    public void setAnimatorPersonagem(Animator animacaoJogador)
    {
        this.anAnimacaoJogador = animacaoJogador;
    }

    public class HabilidadeUm : Personagem
    {
        private int dano;

        void setDano(int dano)
        {
            this.dano = dano;
        }
        void ataqueDominacao()
        {
            anAnimacaoJogador.SetTrigger("habilidade-Um");
        }

        void gastarEnergia(int energia)
        {
            int energiaAtual = getIntEnergia();
            energiaAtual -= energia;
            setIntEnergia(energiaAtual);
        }
    }
    //void HabilidadeDois();
    //void HabilidadeTres();


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
