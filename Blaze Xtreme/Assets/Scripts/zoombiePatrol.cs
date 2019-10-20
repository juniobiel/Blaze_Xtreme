using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombiePatrol : MonoBehaviour
{
    public Transform[] Patrolpoints;
    public float speed=0.5f;
    int currentPoint;
    void Start()
    {
        StartCoroutine("Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Patrol ()
    {
        while (true)
        {

            if (transform.position.x == Patrolpoints[currentPoint].position.x)
            {
                currentPoint++;
            }
            if (currentPoint >= Patrolpoints.Length)
            {
                currentPoint = 0;
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Patrolpoints[currentPoint].position.x, transform.position.y),speed);
          

                yield return null;
            yield return new WaitForSeconds(4f);

            
            
            }
        }
    }
    




