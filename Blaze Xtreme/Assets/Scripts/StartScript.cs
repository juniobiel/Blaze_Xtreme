using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private float contTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contTimer += Time.deltaTime;
        if(contTimer >= 4.0f)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Loading", LoadSceneMode.Single);
            }
        }
    }
}
