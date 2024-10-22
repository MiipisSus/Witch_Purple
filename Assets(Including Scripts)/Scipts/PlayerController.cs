using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public int ins;
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) ins = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ins = 2;
        if (Input.GetKeyDown(KeyCode.Space)) ins = 3;
    }
}
