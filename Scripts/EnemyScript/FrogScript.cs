using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FrogScript : MonoBehaviour

{
    private Animator anim;
    private bool animation_Started;
    private bool animation_Finished;
    private Rigidbody2D mybody;
    private GameObject player;
    private LayerMask playerLayer;
    private int jumpedTimes;
    private bool jumpLeft = true;
    private string coroutine_Name = "FrogJump";


    void Awake()
    {

        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(coroutine_Name);
        player = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG);
    }
    void Update()
    {
        if (!Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer))
        {
           //player.GetComponent<PlayerDamage>().DealDamage();
        }
       
    }
    // Update is called once per frame
    void LateUpdate()
    {

        if(animation_Finished && animation_Started)
        {
            animation_Started = false;

            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
    }

        IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f,4f));

        animation_Started = true;
        animation_Finished = false;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");


        }
        else
        {
            FrogDead();
        }
        StartCoroutine(coroutine_Name);
    }
    void AnimationFinished()
    {
        animation_Finished = true;
        anim.Play("FrogIdleLeft");
    }
    IEnumerator FrogDead()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.BULLET_TAG)
        {
            anim.Play("FrogDead");
            StartCoroutine(FrogDead());
           
        }
    }
}
