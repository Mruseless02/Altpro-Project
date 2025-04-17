using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EvilMage : MonoBehaviour
{
    private GameObject Player;
    public GameObject AttackRange1;
    public GameObject AttackRange2;
    private Vector3 PlayerPos;
    private Vector3 OriginPos;
    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    private Animator animator;
    [SerializeField]
    private float Force;
    [SerializeField]
    private float Timer;
    [SerializeField]
    private float Delay;
    private bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerPos = Player.transform.position;
        OriginPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Sprite = rb.GetComponent<SpriteRenderer>();
        animator = rb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > Delay)
        {
            canAttack = true; 
        }
        if(canAttack)
        {
            Timer = 0;
            animator.Play("EvilMage@Run");
            canAttack = false;
        }
        flip();
        attackFlip();
    }

    private void attackFlip()
    {
        if (Sprite.flipX == true)
        {
            AttackRange1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            AttackRange2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void flip()
    {
        {
            if (transform.position.x > PlayerPos.x)
            {
                Sprite.flipX = true;
            }
            else
            {
                Sprite.flipY = false;
            }
        }
    }
    private void Attack()
    {
        Force = 15;
        Vector3 target = PlayerPos - transform.position;
        rb.velocity = new Vector3(target.x, target.y).normalized * Force;
    }

    private void AttackActive1()
    {
        AttackRange1.SetActive(true);
    }
    private void AttackActive2()
    {
        AttackRange2.SetActive(true);
    }
    private void AttackInactive1()
    {
        AttackRange1.SetActive(false);
    }
    private void AttackInactive2()
    {
        AttackRange2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Force = 0;
            Debug.Log("Attacking");
            animator.Play("EvilMage@Attack");
            Debug.Log("AttackDone");
        }
    }

    private void hasAttack()
    {
        Timer = 0;
        transform.position = OriginPos;
    }
    private void PlaySound()
    {
        AudioManager.PlayAudio(SoundType.Steps);
    }
}
