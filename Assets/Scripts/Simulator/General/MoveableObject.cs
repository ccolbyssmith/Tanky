using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveableObject : RotatableObject
{
    public float xPos
    {
        private set;
        get;
    }
    public float yPos
    {
        private set;
        get;
    }
    public float moveSpeed
    {
        private set;
        get;
    }

    public MoveableObject(float xPos, float yPos, float rotation, float moveSpeed, 
        float rotationSpeed) : base(rotation, rotationSpeed)
    {
        this.xPos = xPos;
        this.yPos = yPos;
        this.moveSpeed = moveSpeed;
    }

    public void moveForwards()
    {
        xPos += (float)(Math.Cos(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        yPos += (float)(Math.Sin(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
    }

    public void moveBackwards()
    {
        xPos -= (float)(Math.Cos(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        yPos -= (float)(Math.Sin(rotation * Math.PI / 180) * moveSpeed) * Time.deltaTime;
    }

    public void moveRight()
    {
        xPos += (float)(Math.Cos((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        yPos += (float)(Math.Sin((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
    }

    public void moveLeft()
    {
        xPos -= (float)(Math.Cos((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
        yPos -= (float)(Math.Sin((rotation - 90) * Math.PI / 180) * moveSpeed) * Time.deltaTime;
    }

    public Vector2 getCoordinate()
    {
        return new Vector2(xPos, yPos);
    }
}
