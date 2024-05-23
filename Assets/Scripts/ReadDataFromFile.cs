using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadDataFromFile : MonoBehaviour
{
    [System.Serializable]
    public struct Question
    {
        public string questionText;
        public string correctAnswer;
    }

    public List<Question> questions = new List<Question>();

    // Путь к файлу CSV
    public string csvFilePath;

    public void Initialize()
    {
        LoadQuestionsFromCSV();
    }

    void LoadQuestionsFromCSV()
    {
        // Чтение всех строк из CSV файла
        string[] csvLines = File.ReadAllLines(csvFilePath);

        foreach (string line in csvLines)
        {
            // Разделение строки на части (вопрос и ответ)
            string[] data = line.Split(',');

            if (data.Length == 2)
            {
                Question question = new Question();
                question.questionText = data[0];
                question.correctAnswer = data[1];
                questions.Add(question);
            }
        }

        // Пример: вывод всех вопросов и ответов в консоль
        foreach (Question q in questions)
        {
            Debug.Log("Question: " + q.questionText + ", Answer: " + q.correctAnswer);
        }
    }

    // Метод для проверки ответа
    public bool CheckAnswer(int questionIndex, string playerAnswer)
    {
        if (questionIndex < 0 || questionIndex >= questions.Count)
        {
            Debug.LogError("Invalid question index");
            return false;
        }

        return questions[questionIndex].correctAnswer.Trim() == playerAnswer.Trim();
    }
}
