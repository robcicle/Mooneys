using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PLAYER MOVEMENT
    [HideInInspector]
    public bool hasStarted = false;

    [SerializeField]
    private Transform[] trackYPos;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Animator animator;

    private Rigidbody2D _rb;
    private int playerCurrTrack = 1;

    [SerializeField]
    float jumpForce = 4f;
    [SerializeField]
    float jumpCooldown = 2f;
    bool isGrounded = false;

    float jumpCooldownTimer;
    [Header("Yo")]

    // PLAYER VALUES
    [SerializeField]
    int playerHealth = 4;
    [Range(0.0f, 100.0f), SerializeField, Tooltip("This messsage sucks mad cock")]
    int playerScore = 0;

    [SerializeField]
    UI_Game uiGame;

    bool isDead = false;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        jumpCooldownTimer = jumpCooldown;
        uiGame.UpdateHealthUI(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x, transform.position.y),
            new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f), groundLayer);

        animator.SetBool("isGrounded", isGrounded);
        animator.SetInteger("playerHealth", playerHealth);

        jumpCooldownTimer -= Time.deltaTime;

        // Get the players inputs (W or S) decide wether to move up or down.
        // #TO IMPROVE ON THIS ADD INPUTS IN THE GAMECONTROLLER AND A SETTINGS MENU TO CHANGE SAID INPUTS
        if (Input.GetKeyDown(KeyCode.W) && hasStarted && isGrounded && !isDead)
            MoveTrack(-1);
        else if (Input.GetKeyDown(KeyCode.S) && hasStarted && isGrounded && !isDead)
            MoveTrack(1);
        else if (Input.GetKeyDown(KeyCode.Space) && hasStarted && isGrounded && jumpCooldownTimer < 0 && !isDead)
        {
            jumpCooldownTimer = jumpCooldown;
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (isDead)
        {
            
            if (Time.timeScale > 0.1)
            {
                Time.timeScale -= Time.unscaledDeltaTime / 3.5f;
            }
            else
            {
                GameController gameController = GameObject.Find("GameManager").GetComponent<GameController>();
                gameController.SetPrevScore(playerScore);
                gameController.ChangeState(GameController.EGameState.GameOver);
            }
        }
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
        if (playerHealth <= 0)
        {
            isDead = true;
        }
        animator.SetTrigger("takeDamage");
        uiGame.UpdateHealthUI(playerHealth);
    }

    public void Fix()
    {
        if (playerHealth < 4)
            playerHealth += 1;
        uiGame.UpdateHealthUI(playerHealth);
    }

    public void Score(int amount)
    {
        playerScore += amount;
        uiGame.UpdateScoreUI(playerScore);
    }
}
