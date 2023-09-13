using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject ScoreBoard;
    public GameObject Win;
    public GameObject Lose;
    private bool ShowingScoreBoard = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleWin()
    {
        Win.SetActive(true);
    }

    public void HandleLose()
    {
        Lose.SetActive(true);
    }

    public void ResetWinLose()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
       

    }

    public void ActivateScoreboard(bool showScoreBoard)
    {
        ShowingScoreBoard = showScoreBoard;
        ScoreBoard.SetActive(showScoreBoard);
    }

    public void ToggleScoreBoard()
    {
        if (ShowingScoreBoard)
        {
            ShowingScoreBoard = false;
            ScoreBoard.SetActive(false);
        }
        else
        {
            ScoreBoard.SetActive(true);
            ShowingScoreBoard = true;
        }
    }
}
