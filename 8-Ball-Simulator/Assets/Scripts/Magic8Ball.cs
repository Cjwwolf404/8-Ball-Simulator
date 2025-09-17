using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Magic8Ball : MonoBehaviour
{
    public TextMeshProUGUI answerText;
    private bool isRunning = false;
    public float fadeDuration;
    private string[] answers =
    {
        "Yes",
        "No",
        "Possibly",
        "Ask again later",
        "Outlook good",
        "Outlook not good",
        "Your future looks bright",
        "Your future looks grim",
        "There's a high possibility",
        "Very doubtful",
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRunning)
        {
            int index = Random.Range(0, answers.Length);
            answerText.text = answers[index];
            StartCoroutine(AnswerAppear());
        }
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
