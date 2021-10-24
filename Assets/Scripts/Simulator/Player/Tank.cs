using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tank : MoveableObject
{
    private TankTurret turret;

    public float maxHealth
    {
        private set;
        get;
    }

    public float health
    {
        private set;
        get;
    }

    public String color
    {
        private set;
        get;
    }

    public Tank(String color, float maxHealth, float xPos, float yPos, float rotation, 
        float moveSpeed, float rotationSpeed, float turretRotationSpeed, String turretType) 
        : base(xPos, yPos, rotation, moveSpeed, rotationSpeed)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        turret = new TankTurret(color, rotation, turretRotationSpeed, turretType);
        this.color = color;
    }

    public void update(List<TankInput.Action> moves)
    {
        for(int i = 0; i < moves.Count; i++)
        {
            if (moves[i] == TankInput.Action.FORWARD)
            {
                base.moveForwards();
            }
            if (moves[i] == TankInput.Action.BACKWARD)
            {
                base.moveBackwards();
            }
            if (moves[i] == TankInput.Action.RIGHT)
            {
                base.rotateRight();
                turret.rotateRight();
            }
            if (moves[i] == TankInput.Action.LEFT)
            {
                base.rotateLeft();
                turret.rotateLeft();
            }
            if (moves[i] == TankInput.Action.TURRET_LEFT)
            {
                turret.rotateLeft();
            }
            if (moves[i] == TankInput.Action.TURRET_RIGHT)
            {
                turret.rotateRight();
            }
        }
    }

    public Projectile shoot()
    {
        return turret.shoot(xPos, yPos);
    }

    public void damage(float damageTaken)
    {
        health -= damageTaken;
    }

    public void heal(float healTaken)
    {
        health += healTaken;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public Quaternion getTurretRotation()
    {
        return turret.getRotation();
    }
}