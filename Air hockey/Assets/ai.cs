using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{

    public float MaxMovementSpeed;
    private Rigidbody2D rb;
    private Vector2 startingPosition;

    public Rigidbody2D ball; //adding the ball

    public Transform playerLimits; //adding player limits
    private playerMovement.limit playerLimit; //struct

    public Transform ballLimits; //addding ball limits
    private playerMovement.limit ballLimit; //struct

    private Vector2 targetPosition;

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget; //to make diffrence between the ball movement and the ai movement

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        playerLimit = new playerMovement.limit(playerLimits.GetChild(0).position.y, playerLimits.GetChild(1).position.y, playerLimits.GetChild(2).position.x, playerLimits.GetChild(3).position.x);

        ballLimit = new playerMovement.limit(ballLimits.GetChild(0).position.y, ballLimits.GetChild(1).position.y, ballLimits.GetChild(2).position.x, ballLimits.GetChild(3).position.x);
    }

    private void FixedUpdate()
    {
        float movementSpeed;

        if (ball.position.y < ballLimit.down)
        {
            if (isFirstTimeInOpponentsHalf)
            {
                isFirstTimeInOpponentsHalf = false;
                offsetXFromTarget = Random.Range(-1f, 1f); //randomizing the offset to make the game smooth
            }

            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f); //randomizing the speed to make the game more smoother while returning
            targetPosition = new Vector2(Mathf.Clamp(ball.position.x + offsetXFromTarget, playerLimit.left, playerLimit.right), startingPosition.y); //returning to starting y position
        }
        else
        {
            isFirstTimeInOpponentsHalf = true;

            movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed); //set the speed to the max speed
            targetPosition = new Vector2(Mathf.Clamp(ball.position.x, playerLimit.left, playerLimit.right), Mathf.Clamp(ball.position.y, playerLimit.down, playerLimit.up)); //go to the ball postion
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime)); //here we move
    }
}