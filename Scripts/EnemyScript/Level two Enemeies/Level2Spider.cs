﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spider : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D mybody;
    private float speed = 2f;
    private Vector3 moveDirection = Vector3.down;
    private string coroutine_Name = "ChangeMovement";

    void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutine_Name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
    }
    void MoveSpider()
    {
        transform.Translate(moveDirection * speed * Time.smoothDeltaTime);

    }
    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(9f);                          //we can alsom use UnityEngine.Random.range
        if (moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }
        StartCoroutine(coroutine_Name);
    }

    IEnumerator SpiderDead()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == MyTags.BULLET_TAG)
        {
            anim.Play("SpiderDead");

            mybody.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(SpiderDead());
            StopCoroutine(coroutine_Name);
        }
        if (target.tag == MyTags.PLAYER_TAG)
        {
            target.GetComponent<Level2PlayerDamage>().DealDamage();
        }
    }
}
