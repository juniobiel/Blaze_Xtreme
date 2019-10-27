using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Personagem;

public class ControladorJogadorUm : MonoBehaviour
{
    private Personagem personagemJogadorUm;
    private Movimentacao sptMovimentacaoPersonagemUm;
    public GameObject prefabPersonagemUm;
    public float x;
    public float y;

    //public bool atack = false;
    //public Transform hitBox;
    //public GameObject hitBoxPrefab;
    
    
    void Start()
    {
        prefabPersonagemUm = Instantiate(prefabPersonagemUm, new Vector2(0, 0), Quaternion.identity);
        personagemJogadorUm = prefabPersonagemUm.GetComponent<Personagem>();
        sptMovimentacaoPersonagemUm = new Movimentacao(personagemJogadorUm);
        sptMovimentacaoPersonagemUm.SetFlModuloVelocidade(2.0f);

        //Define o jogador Parado
        sptMovimentacaoPersonagemUm.EstaParado(x, y);

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("HORIZONTAL0");
        y = Input.GetAxis("VERTICAL0");
        //if (atack == false)
        //{
            sptMovimentacaoPersonagemUm.EstaParado(x, y);
            sptMovimentacaoPersonagemUm.AndarPraBaixo(x, y);
            sptMovimentacaoPersonagemUm.AndarPraCima(x, y);
            sptMovimentacaoPersonagemUm.AndarPraEsquerda(x, y);
            sptMovimentacaoPersonagemUm.AndarPraDireita(x, y);
       // }
			
        //if (Input.GetButtonDown("AZUL0") && atack == false)
        //{
        //    atack = true;
        //    personagemJogadorUm.GetRGBDControladorJogador().velocity = new Vector2(0, 0);
        //    personagemJogadorUm.GetAnimatorPersonagem().SetTrigger("habilidade-Um");
        //}

    }

    //public void OnHitBox()
    //{
    //    GameObject hit = Instantiate(hitBoxPrefab, hitBox.position, hitBox.localRotation);
    //    Destroy(hit.gameObject, 0.05f);
    //}

    //public void NoFimDoAtaque()
    //{
    //    atack = false;
    //}

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    switch (col.gameObject.tag)
    //    {
    //    case "inimigo":
    //        if (! personagemJogadorUm.GetAnimatorPersonagem().GetBool("toma-Hit"))
    //        {
    //            atack = false;
    //                personagemJogadorUm.GetAnimatorPersonagem().SetTrigger("toma-Hit");
    //        }
    //    break;

    //    case "vida":

    //    break;
    //    }
    //}
}
