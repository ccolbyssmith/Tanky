using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TankInput
{
    public enum Action
    {
        FORWARD, BACKWARD, RIGHT, LEFT, TURRET_RIGHT, TURRET_LEFT, SHOOT
    }

    // Update is called once per frame
    public List<List<Action>> updateTanks(List<Tank> tanks)
    {
        List<List<Action>> moves = new List<List<Action>>();
        for(int i = 0; i < tanks.Count; i++)
        {
            moves.Add(new List<Action>());
        }

        for (int i = 0; i < tanks.Count; i++)
        {
            if (tanks[i].color == "Blue")
            {
                updateTank1(moves[0]);
            }
            if (tanks[i].color == "Green")
            {
                updateTank2(moves[1]);
            }
        }
        return moves;
    }

    private void updateTank1(List<Action> moves)
    {
        if(Input.GetKey("w"))
        {
            moves.Add(Action.FORWARD);
        }
        if(Input.GetKey("d"))
        {
            moves.Add(Action.RIGHT);
        }
        if(Input.GetKey("s"))
        {
            moves.Add(Action.BACKWARD);
        }
        if(Input.GetKey("a"))
        {
            moves.Add(Action.LEFT);
        }
        if(Input.GetKey("t"))
        {
            moves.Add(Action.TURRET_LEFT);
        }
        if(Input.GetKey("y"))
        {
            moves.Add(Action.TURRET_RIGHT);
        }
        if (Input.GetKeyDown("u"))
        {
            moves.Add(Action.SHOOT);
        }
    }

    private void updateTank2(List<Action> moves)
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            moves.Add(Action.FORWARD);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            moves.Add(Action.RIGHT);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            moves.Add(Action.BACKWARD);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moves.Add(Action.LEFT);
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            moves.Add(Action.TURRET_LEFT);
        }
        if (Input.GetKey(KeyCode.Period))
        {
            moves.Add(Action.TURRET_RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            moves.Add(Action.SHOOT);
        }
    }
}
