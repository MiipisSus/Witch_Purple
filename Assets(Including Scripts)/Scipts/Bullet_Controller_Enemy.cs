using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller_Enemy : MonoBehaviour
{
    public float timer;
    public float speed;
    int bullet_dir;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2.5f;
        speed = 0.2f;
        bullet_dir = (this.transform.parent.gameObject.transform.rotation.y == 0) ? -1 : 1;
        this.gameObject.transform.rotation = Quaternion.Euler(0, (bullet_dir == 1) ? 180 : 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(bullet_dir * speed * Time.deltaTime * 60, 0, 0);
        
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Chractor")
            Destroy(this.gameObject);
    }
}
