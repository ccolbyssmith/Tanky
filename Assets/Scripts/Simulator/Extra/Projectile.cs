using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Projectile : MoveableObject
{
    public String color
    {
        private set;
        get;
    }
    public float damageOutput
    {
        private set;
        get;
    }
    public float distanceTraveled
    {
        private set;
        get;
    }
    public Boolean exploded
    {
        private set;
        get;
    }
    public float range
    {
        private set;
        get;
    }

    public Projectile(String color, float xPos, float yPos, float rotation, 
        float moveSpeed, float rotationSpeed, float damageOutput, float range)
        : base(xPos, yPos, rotation, moveSpeed, rotationSpeed)
    {
        this.damageOutput = damageOutput;
        this.color = color;
        this.range = range;
    }
    new public void moveForwards()
    {
        base.moveForwards();
        float deltaX = (float)(Math.Cos(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        float deltaY = (float)(Math.Sin(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        distanceTraveled += (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    new public void moveBackwards()
    {
        base.moveBackwards();
        float deltaX = -(float)(Math.Cos(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        float deltaY = -(float)(Math.Sin(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        distanceTraveled += (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    new public void moveRight()
    {
        base.moveRight();
        float deltaX = (float)(Math.Cos((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        float deltaY = (float)(Math.Sin((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        distanceTraveled += (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    new public void moveLeft()
    {
        base.moveLeft();
        float deltaX = -(float)(Math.Cos((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        float deltaY = -(float)(Math.Sin((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        distanceTraveled += (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    }

    public void explode()
    {
        exploded = true;
    }
}
