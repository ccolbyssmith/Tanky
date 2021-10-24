using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject
{
    public float rotation
    {
        private set;
        get;
    }
    public float rotationSpeed
    {
        private set;
        get;
    }

    public RotatableObject(float rotation, float rotationSpeed)
    {
        this.rotation = rotation;
        this.rotationSpeed = rotationSpeed;
    }

    public void rotateLeft()
    {
        rotation += rotationSpeed * Time.deltaTime;
        if (rotation > 359)
        {
            rotation -= 360;
        }
    }

    public void rotateRight()
    {
        rotation -= rotationSpeed * Time.deltaTime;
        if (rotation < 0)
        {
            rotation += 360;
        }
    }

    public Quaternion getRotation()
    {
        return Quaternion.Euler(new Vector3(0, 0, rotation + 90));
    }
}
