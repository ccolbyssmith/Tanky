using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject tankHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player") & !collision.gameObject.name.Contains(gameObject.tag))
        {
            tankHit = collision.gameObject;
        }
    }
}
