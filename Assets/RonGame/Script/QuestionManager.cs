using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject[] questions = new GameObject[6];
    public int currentQuestion = 0;
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
        if(Input.GetKeyDown(KeyCode.E))
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
    }
}
