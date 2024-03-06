using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject[] questions = new GameObject[6];
    public int currentQuestion = -1;
    public bool[] correct = new bool[6] { false, false, false, false, false, false };
    void Start()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            NextQuestion();
        }
    }

    public void NextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < questions.Length)
        {
            if (currentQuestion > 0)
            {
                questions[currentQuestion - 1].SetActive(false);
            }
            questions[currentQuestion].SetActive(true);
        }
        else if (currentQuestion == questions.Length)
        {
            questions[currentQuestion - 1].SetActive(false);
            // Debug.Log("Finish");
        }
    }
}
