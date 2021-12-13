using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    bool isClicked = true;
    bool canMove;
    Vector2 playerSize;
    Rigidbody2D rb;

    public Transform limits;

    limit playerLimit;
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
        playerSize = GetComponent<SpriteRenderer>().bounds.extents;
        rb = GetComponent<Rigidbody2D>();

        playerLimit = new limit(limits.GetChild(0).position.y,limits.GetChild(1).position.y,limits.GetChild(2).position.x,limits.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isClicked)
            {
                isClicked = false;
                if ((mousePos.x >= transform.position.x && mousePos.x < transform.position.x + playerSize.x || mousePos.x <= transform.position.x && mousePos.x > transform.position.x - playerSize.x) && (mousePos.y >= transform.position.y && mousePos.y < transform.position.y + playerSize.y || mousePos.y <= transform.position.y && mousePos.y > transform.position.y - playerSize.y))
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
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerLimit.left ,playerLimit.right),Mathf.Clamp(mousePos.y, playerLimit.down,playerLimit.up));
                rb.MovePosition(clampedMousePos);
            }
        }
        else
        {
            isClicked = true;
        }
    }
}
