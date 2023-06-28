using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_game : MonoBehaviour
{
    bool Retry;
    public GameObject Option1;
    public GameObject Option2;
    // Start is called before the first frame update
    void Start()
    {
        Retry = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            Retry = (Retry) ? false : true;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (Retry)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                SceneManager.LoadScene(1);
                
                
        }
        //選項展示
        if (Retry)
        {
            Option1.SetActive(true);
            Option2.SetActive(false);
        }
        else
        {
            Option1.SetActive(false);
            Option2.SetActive(true);
        }
    }
}
