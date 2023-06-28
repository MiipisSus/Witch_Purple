using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Attack : MonoBehaviour
{
    float dis;
    float bullet_timer;
    bool attack;
    public static int dir;
    public GameObject charactor;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet_timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(this.transform.position,charactor.transform.position);
        if (this.transform.position.x < charactor.transform.position.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            dir = 1;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            dir = -1;
        }
        if (dis <= 10)
            attack = true;
        else
        {
            bullet_timer = 2;
            attack = false;
        }
        if(attack)
        {
            if(bullet_timer<=0)
            {
                Instantiate(bullet, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity,this.transform);
                bullet_timer = 3;
            }
            else
            {
                bullet_timer -= Time.deltaTime;
            }
        }
    }
}
