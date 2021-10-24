using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankTurret : RotatableObject
{
    private String color;
    private float projectileSpeed;
    private float damageOutput;
    private float projectileRange;

    public TankTurret(String color, float rotation, float rotationSpeed, String turretType)
        : base(rotation, rotationSpeed)
    {
        this.color = color;
        switch (turretType)
        {
        case "normal":
            {
                this.projectileSpeed = 20;
                this.damageOutput = 5;
                this.projectileRange = 10;
                break;
            }
        }
    }

    public Projectile shoot(float xPos, float yPos)
    {
        float projectileXPos = xPos + (float)(Math.Cos(rotation * Math.PI / 180));
        float projectileYPos = yPos + (float)(Math.Sin(rotation * Math.PI / 180));
        return new Projectile(color, projectileXPos, projectileYPos, rotation, projectileSpeed, 0, damageOutput, projectileRange);
    }
}
