using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ArrowDirection
{
    Up,
    Down,
    Left,
    Right
}

public class wattahgame_ArrowInputRecorder : MonoBehaviour
{
    private List<ArrowDirection> player1Inputs = new List<ArrowDirection>();
    private List<ArrowDirection> player2Inputs = new List<ArrowDirection>();

    public int wattahgamecurrentPlayer = 1; // wattahgamecurrentPlayer をクラス内に移動

    [SerializeField] private int inputCount = 0;
    public int mismatches = 0;
    private int roundsSurvived = 0;

    public wattahgame_riryPlayerMove wattahgame_riryPlayerMove; 
    public wattahgame_wattahPlayerMove wattahgame_wattahPlayerMove;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            AddInput((wattahgamecurrentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Up);
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            AddInput((wattahgamecurrentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Down);
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            AddInput((wattahgamecurrentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            AddInput((wattahgamecurrentPlayer == 1) ? player1Inputs : player2Inputs, ArrowDirection.Right);
        }

        if (player1Inputs.Count >= 4 && player2Inputs.Count >= 4)
        {
            CompareInputs();
            player1Inputs.Clear();
            player2Inputs.Clear();
            wattahgamecurrentPlayer = 1;
            inputCount = 0;
        }

        if (mismatches >= 3)
        {
            LoadRetryScene();
        }

        if (roundsSurvived >= 5)
        {
            LoadClearScene();
        }
    }

    void AddInput(List<ArrowDirection> inputList, ArrowDirection direction)
    {
        inputList.Add(direction);

        Debug.Log("Player " + wattahgamecurrentPlayer + " Input: " + direction);

        if (wattahgamecurrentPlayer == 2 && player1Inputs.Count > inputCount && player1Inputs[inputCount] == direction)
        {
            Debug.Log("Player 1 and Player 2 matched at input " + inputCount);
        }
        else if (wattahgamecurrentPlayer == 2)
        {
            Debug.Log("Mismatch at input " + inputCount + ". Player 1: " + player1Inputs[inputCount] + ", Player 2: " + direction);
            mismatches++;
        }

        inputCount++;
        if (inputCount >= 4)
        {
            wattahgamecurrentPlayer = (wattahgamecurrentPlayer == 1) ? 2 : 1;
            inputCount = 0;
            roundsSurvived++;
            wattahgame_riryPlayerMove.wattahgame_AnimReset();
        }
    }

    void CompareInputs()
    {
        Debug.Log("Mismatch Count: " + mismatches);
    }

    [SerializeField] private string RetryScene;
    [SerializeField] private string ClearScene;
    

    void LoadRetryScene()
    {
        SceneManager.LoadScene(RetryScene);
    }

    void LoadClearScene()
    {
        SceneManager.LoadScene(ClearScene);
    }
}
