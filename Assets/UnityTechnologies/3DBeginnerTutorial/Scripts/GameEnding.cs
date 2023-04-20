using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [Header ("")]
    [SerializeField] bool hasAudioPlayed = false;
    [SerializeField] bool isPlayerAtExit = false;
    [SerializeField] bool isPlayerCaught = false;
    [SerializeField] float displayImageDuration = 1f;
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float timer;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] AudioSource caughtAudio;
    [SerializeField] CanvasGroup exitBackground;
    [SerializeField] CanvasGroup caughtBackground;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        exitAudio = GameObject.Find("Escape").GetComponent<AudioSource>();
        caughtAudio = GameObject.Find("Caught").GetComponent<AudioSource>();
        exitBackground = GameObject.Find("ExitImageBackground").GetComponent<CanvasGroup>();
        caughtBackground = GameObject.Find("CaughtImageBackground").GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit) {
            EndLevel(exitBackground, false, exitAudio);
        }
        else if (isPlayerCaught) {
            EndLevel(caughtBackground, true, caughtAudio);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player) {
            isPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource) {
        if (!hasAudioPlayed) {
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration) {
            if (doRestart) {
                SceneManager.LoadScene(0);
            }
            else {
                Application.Quit();
            }
            
        }
    }

    public void CaughtPlayer() {
        isPlayerCaught = true;
    }
}
