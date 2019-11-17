using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNPC : MonoBehaviour
{
    List<GameObject> listaDeZumbis = new List<GameObject>();
    public GameObject prefabZumbi;
    float contTimer = 0;

    float velocidadeAtual;
    float danoAtual;

    int nivel;
    float tempoRespawn;

    void Start()
    {
        velocidadeAtual = prefabZumbi.GetComponent<ZumbiNPC>().GetFlSpeed();
        danoAtual = prefabZumbi.GetComponent<ZumbiNPC>().GetFlDano();
    }
    void Update()
    {
         contTimer += Time.deltaTime;
         nivel = GameObject.Find("Gerenciador").GetComponent<GerenciadorFase>().GetNivel();
         verificarNivel();

        if (contTimer >= tempoRespawn)
        {
            //Spawna Zumbi
            float[] arrayPosicoes = new float[4];

            float xSub = Random.Range(-5, -15);
            float ySub = Random.Range(-5, -15);
            float xSup = Random.Range(5, 15);
            float ySup = Random.Range(5, 15);
            arrayPosicoes[0] = xSub;
            arrayPosicoes[1] = ySub;
            arrayPosicoes[2] = xSup;
            arrayPosicoes[3] = ySup;

            listaDeZumbis.Add(Instantiate(prefabZumbi, LocalDeSpawn(arrayPosicoes), Quaternion.identity));
            CopiaAtributosZumbi(); //atualizar ao instanciar
            contTimer -= contTimer;
         }
    }


// ------------------------------ Principais Métodos ------------------------------
    private Vector2 LocalDeSpawn(float[] posicoes)
    {
      int seletorHorizontal, seletorVertical;
      float x, y;

      seletorHorizontal = Random.Range(1, 3);
      seletorVertical = Random.Range(1, 3);

      if(seletorHorizontal == 1)
        x = posicoes[0];
      else
        x = posicoes[2];
      if(seletorVertical == 1)
        y = posicoes[1];
      else
        y = posicoes[3];
      return new Vector2(x,y);
    }

    private void verificarNivel()
    {
      if(nivel <= 3)
        tempoRespawn = 10.0f;
      else if(nivel > 3 && nivel <= 9)
        tempoRespawn = 7.5f;
      else
        tempoRespawn = 5.0f;
    }
    public void CopiaAtributosZumbi()
    {
        int indexador = listaDeZumbis.Count - 1;
        ZumbiNPC zumbi = listaDeZumbis[indexador].GetComponent<ZumbiNPC>();

        zumbi.SetFlSpeed(velocidadeAtual);
        zumbi.SetFlDano(danoAtual);
    }

    public void AtualizarTodosNPCs(float dano, float velocidade) //verificar este metodo
    {
        danoAtual += dano;
        velocidadeAtual += velocidade;
        foreach (GameObject aux in listaDeZumbis)
        {
            ZumbiNPC refNPC = aux.GetComponent<ZumbiNPC>();

            refNPC.SetFlDano(danoAtual);
            refNPC.SetFlSpeed(velocidadeAtual);
        }
    }

    public List<GameObject> GetListaZumbi()
    {
        return this.listaDeZumbis;
    }

}
