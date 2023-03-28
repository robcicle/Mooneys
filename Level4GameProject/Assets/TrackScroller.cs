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

    bool hasPassedStart;

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
        switch (_eTrackType)
        {
            case ETrackType.Start:
                if (transform.position.x < -width)
                {
                    Destroy(this.gameObject);
                }
                break;
            case ETrackType.Playing:
                if (transform.localPosition.x < -width)
                {
                    Debug.Log("cok");
                    Vector2 resetPosition = new Vector2(-9.611f, 0);
                    transform.localPosition = resetPosition;
                }
                break;
        }
    }
}
