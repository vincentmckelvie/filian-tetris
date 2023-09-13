using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    private enum States { Idle, Active, Over, Reset};
    private States CurrentState;
    private MoveTetris TetrisHandler;
    private bool Reset = false;
    private bool BoardFinishedMoving = false;
    private string[] Players = new string[] { "vince", "teeps", "nick", "dave" };
    private int CurrentPlayer = 0;
    private int CurrentBoard = 0;

    private UIHandler Ui;
    // Start is called before the first frame update
    void Start()
    {

        CurrentState = States.Idle;
        TetrisHandler = gameObject.GetComponent<MoveTetris>();
        Ui = gameObject.GetComponent<UIHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!Reset)
            {
                switch (CurrentState)
                {
                    case States.Idle:
                        StartGame();
                        break;
                    case States.Over:
                        GameOver();
                        break;
                    case States.Reset:
                        ResetGame();
                        break;
                }
                Reset = true;
            }
        }
        else
        {
            Reset = false;
        }

        if (CurrentState == States.Active)
        {
            if (Input.GetKeyDown("a"))
            {
                Ui.HandleWin();
                CurrentState = States.Over;
            }
            if(Input.GetKeyDown("s"))
            {
                Ui.HandleLose();
                CurrentState = States.Over;
            }
           
        }

        if (Input.GetKeyDown("1"))
        {
            TetrisHandler.ToggleBoard(0);
        }
        if (Input.GetKeyDown("2"))
        {
            TetrisHandler.ToggleBoard(1);
        }
    }

    private void StartGame()
    {
        CurrentState = States.Active;
        TetrisHandler.StartTetrisAnimation();
    }

    private void GameOver()
    {
        Ui.ActivateScoreboard(true);
        Ui.ResetWinLose();
        CurrentState = States.Reset;
    }

        

    public void ResetGame()
    {
        TetrisHandler.Reset();
        CurrentState = States.Idle;
        Ui.ActivateScoreboard(false);

    }
}
