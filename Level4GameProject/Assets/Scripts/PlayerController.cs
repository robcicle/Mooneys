using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int trackAmount = 3;
    [SerializeField]
    private Transform[] trackTransforms;

    private Rigidbody2D _rb;
    private int playerCurrTrack = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MoveTrack(-1);
        else if (Input.GetKeyDown(KeyCode.S))
            MoveTrack(1);
    }

    void MoveTrack(int amount)
    {
        if (playerCurrTrack + amount <= 2 || playerCurrTrack + amount >= 0)
        {
            playerCurrTrack += amount;

            transform.position = new Vector2(transform.position.x, trackTransforms[playerCurrTrack - 1].position.y);
        }
    }
}
