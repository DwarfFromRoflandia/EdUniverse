using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckCorrectAnswer : MonoBehaviour
{
    public ReadDataFromFile _readDataFromFile;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInputField;
    private int currentQuestionIndex = 0;

    public void Initialize()
    {
        DisplayQuestion();
    }

    public void OnSubmitAnswer()
    {
        string playerAnswer = answerInputField.text;

        if (_readDataFromFile.CheckAnswer(currentQuestionIndex, playerAnswer))
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log($"Incorrect. The correct answer is {_readDataFromFile.questions[currentQuestionIndex].correctAnswer}");
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < _readDataFromFile.questions.Count)
        {
            DisplayQuestion();
        }
        else
        {
            Debug.Log("Quiz Completed!");
        }

        answerInputField.text = ""; // Очистка поля ввода
    }

    void DisplayQuestion()
    {
        questionText.text = _readDataFromFile.questions[currentQuestionIndex].questionText;
    }
}
