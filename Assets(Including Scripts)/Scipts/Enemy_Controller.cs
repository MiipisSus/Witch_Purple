using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    //¼Ä¤H¼Æ­È
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            Destroy(this.gameObject);

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Character_weapon")
        {
            Debug.Log(hp);
            hp -= 1;
        }
    }
}
