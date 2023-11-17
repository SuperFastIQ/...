using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private Animator _playerAnimations;
    private SpriteRenderer _playerSprite;
    private BoxCollider2D _playerHitBox;

    [SerializeField] private float _horizontalSpeedMultiplier = 7f;
    [SerializeField] private float _jumpForce = 15f;

    [SerializeField] private LayerMask _jumpableGround;

    private enum PlayerMovementStates
    {
        Idle,
        Running,
        Jumping,
        Falling,
    }

    // Start is called before the first frame update
    void Start() //Stuff that needs to happen when starting the game (initialize)
    {
        Debug.Log("Oy"); //Message in debug window

        _playerRigidBody = GetComponent<Rigidbody2D>(); //aaaaa
        _playerAnimations = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerHitBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis --> any value between -1 and 1
        //GetAxisRaw --> -1, 0 or 1
        float directionX = Input.GetAxisRaw("Horizontal");
        _playerRigidBody.velocity = new Vector2(directionX * _horizontalSpeedMultiplier, _playerRigidBody.velocity.y);
        //if (directionX > 0)                //When moving right (only has 1 possibility/speed)

        //GetKeyDown --> for any key (hardcoded), use KeyCode.X or ""
        //GetButtonDown --> For Input set within unity's inputmanager, use ""
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, _jumpForce); //To access another component within object
        }

        SetAnimation(directionX, _playerRigidBody.velocity);
    }

    /// <summary>
    /// Setting the correct animation to play of the player
    /// </summary>
    /// <param name="directionX"> The x input of the player </param>
    /// <param name="velocity"> The speed of the player </param>
    private void SetAnimation(float directionX, Vector2 velocity)
    {
        PlayerMovementStates state = PlayerMovementStates.Idle; // Set a default state

        if (velocity.y > 0.1)
        {
            state = PlayerMovementStates.Jumping;
        }
        else if (velocity.y < -0.1)
        {
            state = PlayerMovementStates.Falling;
        }
        else if (velocity.x != 0)
        {
            state = PlayerMovementStates.Running;
        }

        if (directionX > 0)
        {
            _playerSprite.flipX = false;
        }
        else if (directionX < 0)
        {
            _playerSprite.flipX = true;
        }

        _playerAnimations.SetInteger("PlayerState", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_playerHitBox.bounds.center, _playerHitBox.bounds.size, 0f, Vector2.down, 0.1f, _jumpableGround);
    }
}
