using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStage_Entry : MonoBehaviour
{
    float start_timer = 2.5f;
    public GameObject start;
    bool start_tag;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 900, true);
        start_tag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && start_tag)
        {
            SceneManager.LoadScene(1);
        }
        if (start_timer<=0)
        {
            start.SetActive(true);
            start_tag = true;
        }
        else
        {
            start_timer -= Time.deltaTime;
        }
    }
}
