using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    bool hasPlayerEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasPlayerEntered && collision.gameObject.layer == 6)
        {
            hasPlayerEntered = true;
            collision.GetComponent<PlayerController>().Hit();
        }
    }
}
