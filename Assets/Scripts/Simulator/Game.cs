using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    public Camera cam;
    public GameObject displayManager;
    public int numberOfTanks;
    public float tankMoveSpeed;
    public float tankRotationSpeed;
    public float tankTurretRotationSpeed;
    public float tankMaxHealth;
    private List<Tank> tanks = new List<Tank>();
    private List<Projectile> projectiles = new List<Projectile>();
    private List<int> tankRemovalIndexes = new List<int>();
    private List<int> projectileRemovalIndexes = new List<int>();
    private float camHeight;
    private float camWidth;
    private System.Random random = new System.Random();
    private TankInput tankInput = new TankInput();
    private List<String> tankColor = new List<String>()
    {
        "Blue",
        "Green",
        "Red",
        "Yellow"
    };
    private List<List<TankInput.Action>> previousMoves = new List<List<TankInput.Action>>();

    // Awake is called before Start()
    void Awake()
    {
        camHeight = cam.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;
        for (int i = 0; i < numberOfTanks; i++)
        {
            Tank aTank = new Tank(tankColor[i], tankMaxHealth, 5 * (float) Math.Sin(i * .5 * Math.PI),
                5 * (float) Math.Cos(i * .5 * Math.PI), 270, tankMoveSpeed, 
                tankRotationSpeed, tankTurretRotationSpeed, "normal");
            tanks.Add(aTank);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<List<TankInput.Action>> moves = tankInput.updateTanks(tanks);
        moveTanks(moves);
        destroyTanks();
        addProjectiles(moves);
        destroyProjectiles();
        previousMoves = moves;
    }

    private void destroyTanks()
    {
        for (int i = 0; i < tanks.Count; i++)
        {
            if (tanks[i].health <= 0)
            {
                tanks.RemoveAt(i);
                tankRemovalIndexes.Add(i);
            }
        }
    }

    private void addProjectiles(List<List<TankInput.Action>> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            for (int j = 0; j < moves[i].Count; j++)
            {
                if (moves[i][j] == TankInput.Action.SHOOT)
                {
                    projectiles.Add(tanks[i].shoot());
                }
            }
        }
    }

    private void destroyProjectiles()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            projectiles[i].moveForwards();
            if (projectiles[i].distanceTraveled >= projectiles[i].range)
            {
                projectiles[i].explode();
            }
            if (projectiles[i].exploded)
            {
                projectiles.RemoveAt(i);
                projectileRemovalIndexes.Add(i);
            }
        }
    }

    private void moveTanks(List<List<TankInput.Action>> moves)
    {
        for (int i = 0; i < tanks.Count; i++)
        {
            tanks[i].update(moves[i]);
        }
    }

    public void resetTankRemovalIndex()
    {
        tankRemovalIndexes.Clear();
    }
    public void resetProjectileRemovalIndex()
    {
        projectileRemovalIndexes.Clear();
    }
    public int getTankRemovalIndex(int i)
    {
        return tankRemovalIndexes[i];
    }
    public int getProjectileRemovalIndex(int i)
    {
        return projectileRemovalIndexes[i];
    }
    public int getTankRemovalSize()
    {
        return tankRemovalIndexes.Count;
    }
    public int getProjectileRemovalSize()
    {
        return projectileRemovalIndexes.Count;
    }
    public Tank getTank(int i)
    {
        return tanks[i];
    }
    public Projectile getProjectile(int i)
    {
        return projectiles[i];
    }
    public int getTanksSize()
    {
        return tanks.Count;
    }
    public int getProjectilesSize()
    {
        return projectiles.Count;
    }
    public void stopTank(int i)
    {
        List<TankInput.Action> newMoves = new List<TankInput.Action>();
        for(int j = 0; j < previousMoves[i].Count; j++)
        {
            if(previousMoves[i][j] == TankInput.Action.BACKWARD)
            {
                newMoves.Add(TankInput.Action.FORWARD);
            }
            else if (previousMoves[i][j] == TankInput.Action.FORWARD)
            {
                newMoves.Add(TankInput.Action.BACKWARD);
            }
            else if (previousMoves[i][j] == TankInput.Action.RIGHT)
            {
                newMoves.Add(TankInput.Action.LEFT);
            }
            else if (previousMoves[i][j] == TankInput.Action.LEFT)
            {
                newMoves.Add(TankInput.Action.RIGHT);
            }
        }
        tanks[i].update(newMoves);
    }
}
