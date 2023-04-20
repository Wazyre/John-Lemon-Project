using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text theText = GetComponent<TMP_Text>();
        StartCoroutine(FadeTextInOut(1f, theText));
    }

    IEnumerator FadeTextInOut(float t, TMP_Text text) {
        yield return new WaitForSeconds(2);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(5);

        while (text.color.a > 0f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
