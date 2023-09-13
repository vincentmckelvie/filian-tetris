using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoveTetris : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject TetrisBoard;
    private Vector3 startPos;
    public Transform endPos;
    private Director gameDirector;
    internal int BoardAmount; 
    void Start()
    {
        gameDirector = gameObject.GetComponent<Director>();
        startPos = TetrisBoard.transform.position;
        BoardAmount = TetrisBoard.transform.childCount;
        ToggleBoard(0);
        //StartTetrisAnimation();
    }

    public void StartTetrisAnimation()
    {
        iTween.MoveTo(TetrisBoard, iTween.Hash("position", endPos, "time", 7f, "easeType", iTween.EaseType.linear, "onComplete", "TetrisBoardMoveFinished"));
    }

    public void TetrisBoardMoveFinished()
    {
    }

    public void ToggleBoard(int index)
    {
        foreach (Transform t in TetrisBoard.transform)
        {
            t.gameObject.SetActive(false);
        }

        int i = 0;
        foreach (Transform t in TetrisBoard.transform)
        {
            if (i == index) { 
                t.gameObject.SetActive(true);
            }

            i++;
        }

    }

    public void Reset()
    {
        TetrisBoard.transform.position = startPos;
    }


    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("hiiis");

    }
}
