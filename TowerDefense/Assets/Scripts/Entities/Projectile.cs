﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public GameObject target;
    public float duration;
    public float speed;
    private float elapsedTime = 0f;

    Projectile(GameObject target, float duration, float speed)
    {
        this.target = target;
        this.duration = duration;
        this.speed = speed;
    }

    public Projectile setData(GameObject target, float duration, float speed)
    {
        this.target = target;
        this.duration = duration;
        this.speed = speed;

        return this;
    }

    void FixedUpdate()
    {
        if (target != null) {

            Vector3 enemy = target.transform.position;
            enemy.y = 3f;

            if (elapsedTime >= duration) Destroy(gameObject);

            transform.LookAt(enemy);
            transform.position = Vector3.MoveTowards(transform.position, enemy, speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }
    // cuando colisione con un objeto de los que indico se destruya.
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
