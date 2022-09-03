﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;
    private Bounds cameraBounds;
    private Transform target;

    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private bool followPlayer;


    void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
        cameraBounds = myCol.bounds;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).transform;
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        followPlayer = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 aheadTargetPos = target.position + Vector3.forward * offsetZ;

            if (aheadTargetPos.x >= transform.position.x)
            {
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,aheadTargetPos,
                    ref currentVelocity,cameraSpeed);

                transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);
                lastTargetPosition = target.position;

            }
        }
    }
}
