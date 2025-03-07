using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    private enum ETrackType
    {
        Start,
        Playing,
        End
    }

    [SerializeField]
    private ETrackType _eTrackType = ETrackType.Start;

    private BoxCollider2D _collider;
    private Rigidbody2D _rb;

    private float width;
    [SerializeField]
    private float scrollSpeed = -4f;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();

        width = _collider.size.x;

        _rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_eTrackType)
        {
            case ETrackType.Start:
                if (transform.position.x < -width)
                {
                    Destroy(this.gameObject);
                }
                else if (transform.position.x < -9)
                {
                    GameObject.Find("Player").GetComponent<PlayerController>().hasStarted = true;
                    GameObject.Find("Entities").GetComponent<EntitySpawner>().hasStarted = true;
                }
                break;
            case ETrackType.Playing:
                if (transform.position.x < -width)
                {
                    Vector2 resetPosition = new Vector2(width * 2f, 0);
                    transform.position = (Vector2)transform.position + resetPosition;
                }
                break;
        }
    }
}
