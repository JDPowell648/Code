using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private Vector2 lastDirection;

    [SerializeField] private float currentFallingSpeed;
    [SerializeField] private LayerMask rayLayer;

    [SerializeField] private float rightRayLen;
    [SerializeField] private float rightRaySpace;

    [SerializeField] private float leftRayLen;
    [SerializeField] private float leftRaySpace;

    [SerializeField] private float upRayLen;
    [SerializeField] private float upRaySpace;

    [SerializeField] private float downRayLen;
    [SerializeField] private float downRaySpace;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravForce;

    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;

    enum runStates
    {
        idle, walking, running
    }

    enum airborne
    {
        grounded, falling, wallGrab
    }

    enum jumpStates
    {
        groundJump, doubleJump, wallJump, neutral, noMoreJumps
    }

    [SerializeField] private airborne airState;
    [SerializeField] private runStates runState;
    [SerializeField] private jumpStates jumpState;

    void Start()
    {
        airState = airborne.grounded;
        runState = runStates.idle;
    }

    // Update is called once per frame

    private void Update()
    {
        animations();
    }

    void FixedUpdate()
    {
        jump();
        movement();
        physics();
    }
    private void animations()
    {
        if (runState == runStates.idle)
        {
            anim.SetBool("isIdle", true);
        }
        else
        {
            anim.SetBool("isIdle", false);
        }

        if (runState == runStates.walking)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            if (currentSpeed >= 0)
            {
                currentSpeed -= .2f + (5 * Time.deltaTime);
            }if(currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        }
    }

    private void physics()
    {
        gravity();
        headCheck();
        if (runState == runStates.walking)
        {
            if (currentSpeed <= maxSpeed)
            {
                currentSpeed += .2f + (5 * Time.deltaTime);
            }
            if (currentSpeed >= maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else if (airState == airborne.falling)
        {
            if (currentSpeed >= 0)
            {
                currentSpeed -= .2f;
            }
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        } 
        else if (airState != airborne.falling)
        {
            if (currentSpeed >= 0)
            {
                currentSpeed -= .2f + (5 * Time.deltaTime);
            }
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        }

        if (airState == airborne.falling && runState != runStates.walking)
        {
            if(lastDirection == Vector2.left && !drawRayHoriz(Vector2.left, leftRayLen + (.03f * currentSpeed), leftRaySpace))
            {
                Vector3 direction = new Vector3(transform.position.x - (.01f * currentSpeed), transform.position.y, transform.position.z);
                transform.position = direction;
            }
            else if(lastDirection == Vector2.right && !drawRayHoriz(Vector2.right, rightRayLen + (.03f * currentSpeed), rightRaySpace))
            {
                Vector3 direction = new Vector3(transform.position.x + (.01f * currentSpeed), transform.position.y, transform.position.z);
                transform.position = direction;
            }
        }
    }
    private void gravity()
    {
        if (!drawRayVert(.22f, Vector2.down, downRayLen, downRaySpace))
        {
            airState = airborne.falling;
        }
        else
        {
            airState = airborne.grounded;
            currentFallingSpeed = 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, rayLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3((transform.position.x - leftRaySpace / 2), transform.position.y, transform.position.z), Vector2.down, 100f, rayLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3((transform.position.x + rightRaySpace / 2), transform.position.y, transform.position.z), Vector2.down, 100f, rayLayer);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector3((transform.position.x - leftRaySpace / 4), transform.position.y, transform.position.z), Vector2.down, 100f, rayLayer);
        RaycastHit2D hit5 = Physics2D.Raycast(new Vector3((transform.position.x + rightRaySpace / 4), transform.position.y, transform.position.z), Vector2.down, 100f, rayLayer);
        Debug.DrawRay(transform.position, Vector2.down * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x - leftRaySpace / 2), transform.position.y, transform.position.z), Vector2.down * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x - leftRaySpace / 4), transform.position.y, transform.position.z), Vector2.down * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x + rightRaySpace / 2), transform.position.y, transform.position.z), Vector2.down * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x + rightRaySpace / 4), transform.position.y, transform.position.z), Vector2.down * 100f, Color.cyan);

        double leftDist = Math.Round(hit2.distance, 2);
        double leftinnerDist = Math.Round(hit4.distance, 2);
        double centerDist = Math.Round(hit.distance, 2);
        double rightDist = Math.Round(hit3.distance, 2);
        double rightinnerDist = Math.Round(hit5.distance, 2);

        if (hit.collider != null)
        {
            Debug.Log(leftDist.ToString() +" " + leftinnerDist.ToString() + "   " + centerDist.ToString() + "   " + rightinnerDist.ToString() +" "+ rightDist.ToString() + "   " + currentFallingSpeed.ToString());
            if (-hit.distance >= currentFallingSpeed - gravForce && airState == airborne.falling)
            {
                //making sure my next gravity transform is valid
                Vector3 direction = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
                transform.position = direction;
            }
            else if (airState == airborne.falling)
            {
                //applying gravity
                Vector3 direction = new Vector3(transform.position.x, transform.position.y + currentFallingSpeed, transform.position.z);
                transform.position = direction;
                currentFallingSpeed -= gravForce;
            }
            if (airState == airborne.grounded && hit.distance < .24f && (leftDist == centerDist && centerDist == rightDist && leftDist == leftinnerDist && rightDist == rightinnerDist))
            {
                //correcting distance from ground if incorrect
                Vector3 direction = new Vector3(transform.position.x, transform.position.y + (.25f - hit.distance), transform.position.z);
                transform.position = direction;
            }
            else if (airState == airborne.grounded && hit.distance > .26f && (leftDist == centerDist && centerDist == rightDist && leftDist == leftinnerDist && rightDist == rightinnerDist))
            {
                Vector3 direction = new Vector3(transform.position.x, transform.position.y - (hit.distance - .25f), transform.position.z);
                transform.position = direction;
            }
        }
    }

    private void headCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 100f, rayLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3((transform.position.x - leftRaySpace / 2), transform.position.y, transform.position.z), Vector2.up, 100f, rayLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3((transform.position.x + rightRaySpace / 2), transform.position.y, transform.position.z), Vector2.up, 100f, rayLayer);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector3((transform.position.x - leftRaySpace / 4), transform.position.y, transform.position.z), Vector2.up, 100f, rayLayer);
        RaycastHit2D hit5 = Physics2D.Raycast(new Vector3((transform.position.x + rightRaySpace / 4), transform.position.y, transform.position.z), Vector2.up, 100f, rayLayer);
        Debug.DrawRay(transform.position, Vector2.up * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x - leftRaySpace / 2), transform.position.y, transform.position.z), Vector2.up * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x - leftRaySpace / 4), transform.position.y, transform.position.z), Vector2.up * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x + rightRaySpace / 2), transform.position.y, transform.position.z), Vector2.up * 100f, Color.cyan);
        Debug.DrawRay(new Vector3((transform.position.x + rightRaySpace / 4), transform.position.y, transform.position.z), Vector2.up * 100f, Color.cyan);

        double leftDist = Math.Round(hit2.distance, 2);
        double leftinnerDist = Math.Round(hit4.distance, 2);
        double centerDist = Math.Round(hit.distance, 2);
        double rightDist = Math.Round(hit3.distance, 2);
        double rightinnerDist = Math.Round(hit5.distance, 2);

        if (airState == airborne.falling)
        {
            if (hit.collider != null)
            {
                if (centerDist <= .25)
                {
                    currentFallingSpeed -= .02f;
                }
            }
            if (hit2.collider != null && hit4.collider != null)
            {
                if (leftDist <= .25 && leftDist == leftinnerDist)
                {
                    currentFallingSpeed -= .02f;
                }
            }
            if (hit3.collider != null && hit5.collider != null)
            {
                if (rightDist <= .25 && rightDist == rightinnerDist)
                {
                    currentFallingSpeed -= .02f;
                }
            }
        }
    }

    private void movement()
    {
        if (Input.GetKey(KeyCode.A) && !drawRayHoriz(Vector2.left, leftRayLen, leftRaySpace))
        {
            runState = runStates.walking;
            Vector3 direction = new Vector3(transform.position.x - (.01f * currentSpeed), transform.position.y, transform.position.z);
            transform.position = direction;
            sprite.flipX = true;
            lastDirection = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) && !drawRayHoriz(Vector2.right, rightRayLen, rightRaySpace))
        {
            runState = runStates.walking;
            Vector3 direction = new Vector3(transform.position.x + (.01f * currentSpeed), transform.position.y, transform.position.z);
            transform.position = direction;
            sprite.flipX = false;
            lastDirection = Vector2.right;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            runState = runStates.idle;
        }
    }

    private void jump()
    {
        jumpManager();

        if (Input.GetKeyDown(KeyCode.Space) && (jumpState == jumpStates.doubleJump))
        {
            currentFallingSpeed = 0;
            jumpState = jumpStates.noMoreJumps;
            jumpPhysics();
        }
        if (Input.GetKey(KeyCode.Space) && jumpState == jumpStates.groundJump)
        {
            jumpPhysics();
        }
    }

    private void jumpPhysics()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, .5f, rayLayer);

        if (hit.collider == null)
        {
            currentFallingSpeed = jumpForce;
        }
        else
        {
            currentFallingSpeed = hit.distance - .25f;
        }
        if (currentFallingSpeed >= 0)
        {
            Vector3 direction = new Vector3(transform.position.x, transform.position.y + currentFallingSpeed, transform.position.z);
            transform.position = direction;
        }
    }

    private void jumpManager()
    {
        if(drawRayJump(.22f, Vector2.down, downRayLen, downRaySpace))
        {
            jumpState = jumpStates.groundJump;
        }
        else if(!drawRayVert(.22f, Vector2.down, downRayLen, downRaySpace) && jumpState != jumpStates.noMoreJumps && jumpState != jumpStates.wallJump)
        {
            jumpState = jumpStates.doubleJump;
        }
        if (Input.GetKey(KeyCode.LeftControl) && airState != airborne.grounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rightRayLen*2, rayLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left, leftRayLen*2, rayLayer);
            if (hit.collider != null || hit2.collider != null)
            {
                jumpState = jumpStates.wallJump;
                currentFallingSpeed = -.02f;
            }
        }

        if (jumpState == jumpStates.wallJump)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rightRayLen*2, rayLayer);
            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left, leftRayLen*2, rayLayer);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (hit.collider != null)
                {
                    currentSpeed = 7;
                    Vector3 direction = new Vector3(transform.position.x - (.01f * currentSpeed), transform.position.y, transform.position.z);
                    transform.position = direction;
                    sprite.flipX = true;
                    lastDirection = Vector2.left;
                    jumpPhysics();
                }
                if (hit2.collider != null)
                {
                    currentSpeed = 7;
                    Vector3 direction = new Vector3(transform.position.x + (.01f * currentSpeed), transform.position.y, transform.position.z);
                    transform.position = direction;
                    sprite.flipX = false;
                    lastDirection = Vector2.right;
                    jumpPhysics();
                }
                jumpState = jumpStates.noMoreJumps;
            }
        }

    }

    private bool drawRayHoriz(Vector2 direction, float rayLen, float raySpacing)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLen, rayLayer);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.green);
        }
        RaycastHit2D hit2 = new RaycastHit2D();
        RaycastHit2D hit3 = new RaycastHit2D();
        RaycastHit2D hit4 = new RaycastHit2D();
        RaycastHit2D hit5 = new RaycastHit2D();
        if (direction == Vector2.right || direction == Vector2.left)
        {
            hit2 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y + raySpacing * 2), transform.position.z), direction, rayLen, rayLayer);
            hit3 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y - raySpacing * 2), transform.position.z), direction, rayLen, rayLayer);
            hit4 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y + raySpacing), transform.position.z), direction, rayLen, rayLayer);
            hit5 = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y - raySpacing), transform.position.z), direction, rayLen, rayLayer);
            if (hit2.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + raySpacing * 2, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + raySpacing * 2, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit3.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - raySpacing * 2, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - raySpacing * 2, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit4.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + raySpacing, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y + raySpacing, transform.position.z), direction * rayLen, Color.green);
            }
            if (hit5.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - raySpacing, transform.position.z), direction * rayLen, Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x), transform.position.y - raySpacing, transform.position.z), direction * rayLen, Color.green);
            }
        }

        if (hit.collider != null || hit2.collider != null && hit4.collider != null || hit3.collider != null && hit5.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool drawRayVert(float position, Vector2 direction, float rayLen, float raySpacing) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLen, rayLayer);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.green);
        }
        RaycastHit2D hit2 = new RaycastHit2D();
        RaycastHit2D hit3 = new RaycastHit2D();
        RaycastHit2D hit4 = new RaycastHit2D();
        RaycastHit2D hit5 = new RaycastHit2D();
        if (direction == Vector2.up || direction == Vector2.down)
        {
            hit2 = Physics2D.Raycast(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit3 = Physics2D.Raycast(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit4 = Physics2D.Raycast(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit5 = Physics2D.Raycast(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            if (hit2.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit3.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit4.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit5.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
        }
        if (hit.collider != null || (hit2.collider != null && hit4.collider != null) || (hit3.collider != null && hit5.collider != null))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool drawRayJump(float position, Vector2 direction, float rayLen, float raySpacing)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLen, rayLayer);

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, direction * rayLen, Color.green);
        }
        RaycastHit2D hit2 = new RaycastHit2D();
        RaycastHit2D hit3 = new RaycastHit2D();
        RaycastHit2D hit4 = new RaycastHit2D();
        RaycastHit2D hit5 = new RaycastHit2D();
        if (direction == Vector2.up || direction == Vector2.down)
        {
            hit2 = Physics2D.Raycast(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit3 = Physics2D.Raycast(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit4 = Physics2D.Raycast(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            hit5 = Physics2D.Raycast(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction, rayLen - position, rayLayer);
            if (hit2.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit3.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing * 2), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit4.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x + raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
            if (hit5.collider != null)
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.red);
            }
            else
            {
                Debug.DrawRay(new Vector3((transform.position.x - raySpacing), transform.position.y - position, transform.position.z), direction * (rayLen - position), Color.green);
            }
        }
        if (hit.collider != null || hit2.collider != null || hit4.collider != null || hit3.collider != null || hit5.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
