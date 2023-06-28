using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float timer;
    public float speed;
    int bullet_dir;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2;
        speed = 0.5f;
        bullet_dir = Charactor_Controller.dir;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(bullet_dir*speed*Time.deltaTime*60,0,0);
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }
}
