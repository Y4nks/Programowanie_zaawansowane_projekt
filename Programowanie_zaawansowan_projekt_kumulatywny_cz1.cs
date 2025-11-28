using System;
using System.Collections.Generic;

public class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
}

public class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; } = new List<Answer>();

    public Question(string text)
    {
        Text = text;
    }

    public void AddAnswer(Answer answer)
    {
        Answers.Add(answer);
    }

    // Sprawdza, czy odpowiedź o podanym indeksie jest poprawna
    public bool IsCorrect(int answerIndex)
    {
        if (answerIndex < 0 || answerIndex >= Answers.Count)
            return false;

        return Answers[answerIndex].IsCorrect;
    }
}

public class Quiz
{
    public string Title { get; set; }
    public List<Question> Questions { get; } = new List<Question>();

    public Quiz(string title)
    {
        Title = title;
    }

    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    // Oblicza wynik na podstawie odpowiedzi użytkownika
    public int CheckScore(List<int> userAnswers)
    {
        int score = 0;

        for (int i = 0; i < Questions.Count; i++)
        {
            if (i < userAnswers.Count && Questions[i].IsCorrect(userAnswers[i]))
            {
                score++;
            }
        }

        return score;
    }
}

public class Program
{
    public static void Main()
    {
        var quiz = new Quiz("Quiz z C#");

        var q1 = new Question("Które słowo kluczowe służy do dziedziczenia?");
        q1.AddAnswer(new Answer("extends", false));
        q1.AddAnswer(new Answer("inherits", false));
        q1.AddAnswer(new Answer(":", true));
        quiz.AddQuestion(q1);

        var q2 = new Question("Co oznacza OOP?");
        q2.AddAnswer(new Answer("Object Oriented Programming", true));
        q2.AddAnswer(new Answer("Only One Process", false));
        quiz.AddQuestion(q2);

        // Odpowiedzi użytkownika (indeksy)
        var userAnswers = new List<int> { 2, 0 };

        int wynik = quiz.CheckScore(userAnswers);
        Console.WriteLine($"Twój wynik: {wynik}/{quiz.Questions.Count}");
    }
}
