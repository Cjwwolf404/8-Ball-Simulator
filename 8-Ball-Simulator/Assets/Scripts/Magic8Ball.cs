using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class Magic8Ball : MonoBehaviour
{
    public TextMeshProUGUI answerText;

    public Slider optimismSlider;
    private float optimismLevel = 0.5f;

    private bool isRunning = false;
    public float fadeDuration;

    private string[] positiveAnswers =
    {
        "Yes",
        "Possibly",
        "Outlook good",
        "Your future looks bright",
        "There's a high possibility",
    };

    private string[] negativeAnswers =
    {
        "No",
        "Ask again later",
        "Outlook not good",
        "Your future looks grim",
        "Very doubtful",
    };

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRunning)
        {
            ChooseAnswer();
        }
    }

    public void ChooseAnswer()
    {
        float rand = Random.value;
        string answer;

        if (rand < (1 - optimismLevel))
        {
            answer = negativeAnswers[Random.Range(0, negativeAnswers.Length)];
        }
        else
        {
            answer = positiveAnswers[Random.Range(0, positiveAnswers.Length)];
        }

        answerText.text = answer;
        StartCoroutine(AnswerAppear());
    }

    public void ChangeOptimismLevel()
    {
        optimismLevel = optimismSlider.value;
    }

    IEnumerator AnswerAppear()
    {
        isRunning = true;

        float fadeTimer = 0f;

        while (fadeTimer < fadeDuration)
        {
            float alpha = fadeTimer / fadeDuration;
            answerText.color = new Color(answerText.color.r, answerText.color.g, answerText.color.b, alpha);
            fadeTimer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        fadeTimer = 0;

        while (fadeTimer < fadeDuration)
        {
            float alpha = 1 - (fadeTimer / fadeDuration);
            answerText.color = new Color(answerText.color.r, answerText.color.g, answerText.color.b, alpha);
            fadeTimer += Time.deltaTime;
            yield return null;
        }

        isRunning = false;
    }
}
