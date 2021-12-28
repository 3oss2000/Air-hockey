using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Score ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;
    public float MaxSpeed;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(Score.score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(Score.score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private IEnumerator ResetPuck(bool IsAiScored) //so we can yield (wait for something to happen)
    {
        rb.velocity = new Vector2(0,0); //stop the ball
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.position = new Vector2(0, 0); // return to center

        if(IsAiScored)
            rb.position = new Vector2(0,-1);
        else
            rb.position = new Vector2(0,1);
    }

    private void FixedUpdate() {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}