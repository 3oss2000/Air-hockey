using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public enum score //text representation of numbers -- it is static
    {
        AiScore, PlayerScore
    }

    public Text AiScoreTxt, PlayerScoreTxt;
    private int aiScore, playerScore;

    public void Increment(score whichScore)
    {
        if (whichScore == score.AiScore)
            AiScoreTxt.text = (++aiScore).ToString();
        else
            PlayerScoreTxt.text = (++playerScore).ToString();
    }


}