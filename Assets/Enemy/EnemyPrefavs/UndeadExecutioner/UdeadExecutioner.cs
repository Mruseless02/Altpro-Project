using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class UdeadExecutioner : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject AttackRad_Vertical;
    [SerializeField]
    private GameObject AttackRad_Horizontal;
    [SerializeField]
    private GameObject Summons;
    [SerializeField]
    private GameObject[] SummonPos;
    private Animator animator;
    public GameObject Player;
    private Vector3 Origin;
    public UndeadSummon[] Spirit;
    private float Force;
    private float  timer = 0;
    private float SpawnTime = 0;
    [SerializeField]
    private float SpawnInterval = 2;
    [SerializeField]
    private float interval = 10;
    public int Spawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Origin = gameObject.transform.position;
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        SpawnTime += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer > interval)
        {
            Attack();
        }
        if(SpawnTime > SpawnInterval)
        {
            if (Spawn < SummonPos.Length)
            {
                Summon();
            }
            if(Spawn == SummonPos.Length)
            {
                if (GameObject.FindWithTag("Summons") == null)
                {
                    Spawn = 0;
                }
                var Ghost = GameObject.FindWithTag("Summons").GetComponent<UndeadSummon>();
                for (int i = 0; i < SummonPos.Length-1; i++)
                {
                    Spirit[i] = Ghost;
                    Ghost.AttackPlayer(); 
                }
            }
        }
        Flip();
        FlipAttack();
    }


    private void Flip()
    {
        if(transform.position.x > Player.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    private void FlipAttack()
    {
        if(sprite.flipX == true)
        {
           AttackRad_Horizontal.transform.rotation = Quaternion.Euler(0f, 180f,0f);
           AttackRad_Vertical.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void Attack()
    {

        Force = 10f;
        Vector3 target = Player.transform.position - transform.position;
        animator.Play("Undead@chasePlayer");
        rb.velocity = new Vector3(target.x, target.y).normalized * Force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Force = 0;
            timer = 0;
            AttackRad_Horizontal.SetActive(true);
            animator.Play("Undead@Attack");
        }
    }

    private void AttackVertical()
    {
        AttackRad_Horizontal.SetActive(false);
        AttackRad_Vertical.SetActive(true);
    }
    private void Summon()
    {
        if(Spawn != SummonPos.Length)
        {
            var SpawnPos = SummonPos[Spawn];
            Instantiate(Summons, SpawnPos.transform.position , Quaternion.identity);
            Spawn++;
            SpawnTime = 0;
        }

    }

    private void hasAttack()
    {
        AttackRad_Vertical.SetActive(false);
        transform.position = Origin;
    }
}
