using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    int dir;
    float oringinal_position;

    // Start is called before the first frame update
    void Start()
    {
        dir = -1;
        oringinal_position = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x - oringinal_position < -4)
        {
            dir = 1;
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (this.transform.position.x - oringinal_position > 4) 
        {
            dir = -1;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        this.transform.position += new Vector3(dir * 0.01f, 0, 0);
    }
}
