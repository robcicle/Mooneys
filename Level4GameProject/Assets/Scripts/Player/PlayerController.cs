using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PLAYER MOVEMENT
    public bool hasStarted = false;

    [SerializeField]
    private Transform[] trackYPos;

    private Rigidbody2D _rb;
    private int playerCurrTrack = 1;

    // PLAYER HEALTH
    int playerHealth = 4;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the players inputs (W or S) decide wether to move up or down.
        // #TO IMPROVE ON THIS ADD INPUTS IN THE GAMECONTROLLER AND A SETTINGS MENU TO CHANGE SAID INPUTS
        if (Input.GetKeyDown(KeyCode.W) && hasStarted)
            MoveTrack(-1);
        else if (Input.GetKeyDown(KeyCode.S) && hasStarted)
            MoveTrack(1);
    }

    void MoveTrack(int amount)
    {
        if (playerCurrTrack + amount <= 2 && playerCurrTrack + amount >= 0)
        {
            playerCurrTrack += amount;

            transform.position = new Vector2(transform.position.x, trackYPos[playerCurrTrack].position.y);
        }
    }

    public void Hit()
    {
        playerHealth -= 1;
        Debug.Log("WAH");
    }
}
