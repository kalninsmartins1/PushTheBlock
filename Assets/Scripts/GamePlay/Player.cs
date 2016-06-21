﻿using UnityEngine;
using System.Collections;

public class Player
{
    private GameObject playerCharacterObj;
    private int connectionId;
    private Vector2 homePosition;
    private Vector3 lastSentPosition;

    public Player(GameObject playerCharacterObj, int connectionId)
    {
        this.playerCharacterObj = playerCharacterObj;
        this.connectionId = connectionId;
        var pos = playerCharacterObj.transform.position;
        homePosition = new Vector2(pos.x, pos.y);
        lastSentPosition = new Vector3();
    }

    public int Update()
    {
        int lastCollisionId = -1;
        if(playerCharacterObj.transform.position.y < 0)
        {
            lastCollisionId = playerCharacterObj.GetComponent<CollisionQueue>().LastPlayerCollisionId;
            Reset();
        }

        return lastCollisionId;
    }

    public void Reset()
    {
        playerCharacterObj.transform.position = new Vector2(homePosition.x, homePosition.y);
    }

    public GameObject PlayerCharacterObj
    {
        get { return playerCharacterObj; }
    }

    public int ConnectionId
    {
        get { return connectionId; }
    }

    public Vector3 LastSentPosition
    {
        get { return lastSentPosition; }
        set { lastSentPosition = value; }
    }
}
