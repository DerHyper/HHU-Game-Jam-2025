using System;
using System.Collections;
using TMPro;
using UnityEngine;

public interface ISpeachManager : IManager
{
    void QueueText(string[] texts, Action onFinished, float delay = 3.0f);
}

public class SpeachManager : MonoBehaviour, ISpeachManager
{
    private TMP_Text GetTextField() => GetComponentInChildren<TMP_Text>();

    public void QueueText(string[] texts, Action onFinished, float delay = 3.0f)
    {
        GetTextField().text = texts[0];
        gameObject.SetActive(true);

        StartCoroutine(QueueTextCo(texts, onFinished, delay));
    }

    public IEnumerator QueueTextCo(string[] texts, Action onFinished, float delayFloat)
    {
        WaitForSeconds delay = new(delayFloat);
        var textField = GetTextField();

        foreach (string text in texts)
        {
            textField.text = text;
            yield return delay;
        }

        onFinished?.Invoke();
        gameObject.SetActive(false);
        yield break;
    }
}