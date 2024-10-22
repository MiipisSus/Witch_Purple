using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Charactor_Controller : MonoBehaviour
{
    //物件
    public GameObject Character_bullet;
    public GameObject HP;
    public GameObject MP;
    public GameObject Ins;
    public GameObject Panel;
    public GameObject Restart;
    public TextMeshProUGUI score;
    public TextMeshProUGUI hint;

    int current_ins;
    Rigidbody2D rigid2D;
    Animator animator;
    //動作參數
    float jumpForce =800.0f;
    public float walkForce = 10.0f;
    public float MaxSpeed = 10.0f;
    public static int dir = 0;    //左:0, 右:1
    bool attack_state;
    bool jump_state;
    bool dead_state;
    float MP_timer;
    float Panel_timer;
    float Attack_timer;
    //腳色數值
    public static int hp;
    public static int mp;
    public int star_num = 0;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        attack_state = true;
        jump_state = false;
        dead_state = false;
        hp = 5;
        mp = 5;
        Attack_timer = 1;
        MP_timer = 3;
        Panel_timer = 0;
        current_ins = -1;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.rotation.y == 0)
            dir = -1;
        else
            dir = 1;

        //是否死亡
        if (hp<=0)
        {
            animator.SetTrigger("DeadTrigger");
            dead_state = true;
            Restart.SetActive(true);
        }
        if(dead_state)
        {
            this.enabled = false;
        }
        //Timer
        if (Panel_timer>=0)
        {
            Panel_timer -= Time.deltaTime;
        }
        else
        {
            Panel_timer = 0;
            Panel.SetActive(false);
        }    
        //MP恢復時間
        if (mp < 5)
        {
            if (MP_timer >= 0)
            {
                MP_timer -= Time.deltaTime;
            }
            else
            {
                mp += 1;
                MP.transform.GetChild(mp - 1).gameObject.SetActive(true);
                MP_timer = 3;
            }
        }
        if(!attack_state)
        {
            if (Attack_timer <= 0)
            {
                attack_state = true;
                Attack_timer = 1;
            }
            else
            {
                Attack_timer -= Time.deltaTime;
            }
        }
        //跳躍狀態
        if (rigid2D.velocity.y == 0)
            jump_state = false;
        else
            jump_state = true;
        //左右移動
        if (Input.GetKey("d"))
        {            
                if(rigid2D.velocity.x<8.0f)
                    rigid2D.AddForce(new Vector3(1.0f, 0, 0) * this.walkForce);
            
            if(rigid2D.velocity.y==0)
                animator.SetTrigger("WalkTrigger");
            this.transform.rotation = Quaternion.Euler(0.0f, 180, 0.0f);
            //改變UI指示圖
            ChangeIns(0);
        }
        else if (Input.GetKey("a"))
        {
            if (rigid2D.velocity.x > -8.0f)
                rigid2D.AddForce(new Vector3(1.0f, 0, 0) * (-1) * this.walkForce);               
            
            if (rigid2D.velocity.y == 0)
                animator.SetTrigger("WalkTrigger");
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f) ;
            //改變UI指示圖
            ChangeIns(1);
        }
        //跳躍
        if (Input.GetKeyDown(KeyCode.Space) && !jump_state )  
        {
            jump_state = true;
            this.rigid2D.velocity = new Vector3(0, 0, 0);
            this.rigid2D.AddForce(new Vector3(0, 1f, 0) * this.jumpForce);
            animator.SetTrigger("JumpTrigger");
            //改變UI指示圖
            ChangeIns(2);
        }
        //攻擊
        if (Input.GetKey("z") && mp > 0 && attack_state) 
        {
            attack_state = false;
            mp -= 1;
            MP.transform.GetChild(mp).gameObject.SetActive(false);
            animator.SetTrigger("AttackTrigger");
            Instantiate(Character_bullet, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity) ;
            //改變UI指示圖
            ChangeIns(3);
        }
        //限制速度
        if(rigid2D.velocity.x>MaxSpeed)
        {
            rigid2D.velocity = new Vector3(MaxSpeed, 0, 0);
        }
        //Idle
        if (rigid2D.velocity == new Vector2(0, 0))
            animator.SetTrigger("IdleTrigger");
    }

    //碰撞
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("enemy"))
        {
            hp -= 1;
            animator.SetTrigger("BeingAttackedTrigger");
            if (hp >=0)
            {
                HP.transform.GetChild(hp).gameObject.SetActive(false);              
            }
        }
        if (coll.gameObject.CompareTag("Star"))
        {
            star_num += 1;
            score.text = star_num.ToString();
            coll.gameObject.SetActive(false);
        }
        if(coll.gameObject.CompareTag("Finish"))
        {
            if (star_num >= 8)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Panel_timer = 5;
                Panel.SetActive(true);
                hint.text = "You Need " + (8 - star_num) + " More Star to Open This";
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemy"))
        {
            hp -= 1;
            animator.SetTrigger("BeingAttackedTrigger");
            if (hp >= 0)
            {
                HP.transform.GetChild(hp).gameObject.SetActive(false);
            }
        }
    }
    void ChangeIns(int ins)
    {
        if (current_ins != -1) 
            Ins.transform.GetChild(current_ins).gameObject.SetActive(false);
        Ins.transform.GetChild(ins).gameObject.SetActive(true);
        current_ins = ins;
    }
}
