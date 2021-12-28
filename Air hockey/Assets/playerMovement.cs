using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    bool isClicked = true;
    bool canMove;
    Rigidbody2D rb;

    public Transform limits;
    private Vector2 startingPosition;

    limit playerLimit;
    Collider2D PlayerCollider;
    public struct limit
    {
        public float up, down, left, right;

        public limit(float Up, float Down, float Left, float Right)
        {
            up = Up;
            down = Down;
            left = Left;
            right = Right;

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        startingPosition = rb.position;
        playerLimit = new limit(limits.GetChild(0).position.y, limits.GetChild(1).position.y, limits.GetChild(2).position.x, limits.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ball.WasGoal)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (isClicked)
                {
                    isClicked = false;
                    if (PlayerCollider.OverlapPoint(mousePos))
                    {
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
                if (canMove)
                {
                    Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerLimit.left, playerLimit.right), Mathf.Clamp(mousePos.y, playerLimit.down, playerLimit.up));
                    rb.MovePosition(clampedMousePos);
                }
            }
            else
            {
                isClicked = true;
            }
        }
        else{
            rb.position = startingPosition; //to return the player to the main position after we enter a goal
        }
    }
}
