using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNPC : MonoBehaviour
{
    GameObject hitPrefab; //prefab com animação do Zumbi ao Levar dano
    public GameObject prefabZumbi;
    float contTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        hitPrefab = GameObject.FindWithTag("inimigo");
    }

    // Update is called once per frame
    void Update()
    {
         contTimer += Time.deltaTime;
        if (contTimer >= 6.0f)
         {
            Instantiate(prefabZumbi, new Vector2(5, -5), Quaternion.identity);
            contTimer -= contTimer;
         }
    }

      //void OnTriggerEnter2D(Collider2D col)
     // {
     // switch (col.gameObject.tag)
      //  {
     // case "Taeda_Dominacao":
     // GameObject temp = Instantiate(hitPrefab, transform.position, transform.localRotation);
     // Destroy(temp.gameObject, 0.5f); //tempo da animação do zumbi
     // Destroy(this.gameObject);
    // break;
       // }
     // }
}
