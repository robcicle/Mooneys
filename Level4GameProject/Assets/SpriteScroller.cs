using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Rigidbody2D _rb;

    private float width;
    [SerializeField]
    private float scrollSpeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();

        width = _collider.size.x;
        _collider.enabled = false;

        _rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <- width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
