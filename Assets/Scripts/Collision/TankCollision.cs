using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankCollision : MonoBehaviour
{
    public Boolean passable
    {
        private set;
        get;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Impassable"))
        {
            passable = false;
        }
        else
        {
            passable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        passable = true;
    }
}
