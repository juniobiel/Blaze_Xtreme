using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
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
        if(contTimer >= 7.0f)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
