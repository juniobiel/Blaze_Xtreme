using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public GameObject hitPrefab; //prefab com animação do Zumbi ao Levar dano
    public GameObject playerObject;
    public GameObject prefabZumbi;
    public float speed = 1.3f;

    float playerPositionX;
    float playerPositionY;
    float contTimer = 0;

    void Start()
    {
        //playerPositionX = playerObject.gameObject.transform.position.x;
        //playerPositionY = playerObject.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //contTimer += Time.deltaTime;
        //if (contTimer >= 6.0f)
        //{
        //    Instantiate(prefabZumbi, new Vector2(5, -5), Quaternion.identity);
        //    contTimer -= contTimer;
        //}
        //playerPositionX = playerObject.gameObject.transform.position.x;
        //playerPositionY = playerObject.gameObject.transform.position.y;

        //if (this.gameObject.transform.position.x < playerPositionX)
        //{
        //    this.gameObject.transform.right = Vector2.left;
        //}
        //else
        //{
        //    this.gameObject.transform.right = Vector2.right;
        //}

        //transform.position = Vector2.MoveTowards(transform.position,new Vector2(playerPositionX, playerPositionY) , speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Taeda_Dominacao":
                GameObject temp = Instantiate(hitPrefab, transform.position, transform.localRotation);
                Destroy(temp.gameObject, 0.5f); //tempo da animação do zumbi
                Destroy(this.gameObject);
                break;
        }
    }
}
