﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Vector2 origin;
    public Vector2 direction;
    public bool IsEnemyBullet;
    private Rigidbody2D rigidBody;
    private float speed;
    private float distanceTravelled;

	public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 0.1f;
        distanceTravelled = 0f;
	}
	
	public void Update()
    {
        rigidBody.MovePosition(rigidBody.position + speed * direction);
        distanceTravelled = (rigidBody.position - origin).magnitude;

        if (distanceTravelled > 10)
        {
            Destroy(gameObject);
        }
	}


}
