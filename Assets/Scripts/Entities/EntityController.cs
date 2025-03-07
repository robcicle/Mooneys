using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    private enum EEntityType
    {
        TrackEnemy,
        Enemy,
        Coin,
        Fix
    }

    [SerializeField]
    private EEntityType _eEntityType = EEntityType.TrackEnemy;

    [SerializeField]
    private float scrollSpeed = -4f;

    [SerializeField]
    private int coinValue;

    bool hasPlayerEntered = false;

    private Rigidbody2D _rb;

    private void Start()
    {
        if (_eEntityType != EEntityType.TrackEnemy)
        {
            _rb = GetComponent<Rigidbody2D>();

            _rb.velocity = new Vector2(scrollSpeed, 0);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (_eEntityType)
        {
            case EEntityType.TrackEnemy:
                DamagePlayer(collision);
                break;
            case EEntityType.Enemy:
                DamagePlayer(collision);
                break;
            case EEntityType.Coin:
                if (!hasPlayerEntered && collision.gameObject.layer == 6)
                {
                    hasPlayerEntered = true;
                    collision.GetComponent<PlayerController>().Score(coinValue);
                    Destroy(this.gameObject);                
                }
                break;
            case EEntityType.Fix:
                if (!hasPlayerEntered && collision.gameObject.layer == 6)
                {
                    hasPlayerEntered = true;
                    collision.GetComponent<PlayerController>().Fix();
                    Destroy(this.gameObject);
                }
                break;
        }
        
    }

    void DamagePlayer(Collider2D collision)
    {
        if (!hasPlayerEntered && collision.gameObject.layer == 6)
        {
            hasPlayerEntered = true;
            collision.GetComponent<PlayerController>().Hit();
        }
    }
}
