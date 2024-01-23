using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMesh[] startDisplayText;
    [SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private GameObject gameUI;
	[SerializeField] private GameObject menuUI;
	private Timer timer;

    public event Action GameStarted;

    void Start()
    {
		timer = GetComponent<Timer>();
        timer.TimeChanged += UpdateTimerText;
    }

    IEnumerator StartGameRoutine()
    {
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        for (int i = 3; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            startDisplayText[0].text = startDisplayText[1].text = i.ToString();
            startDisplayText[0].color = startDisplayText[1].color = Color.red;

		}
        startDisplayText[0].text = startDisplayText[1].text = "GO";
		startDisplayText[0].color = startDisplayText[1].color = Color.green;
		GameStarted?.Invoke();
        timer.StartTimer();
	}

    private void UpdateTimerText()
    {
        string time = "Time: ";
        if (timer.Minutes < 10)
        {
            time = String.Concat(time, "0", timer.Minutes.ToString());
		}
        else
        {
			time = String.Concat(time, timer.Minutes.ToString());
		}

        if (timer.Seconds < 10)
        {
            time = String.Concat(time, ":0", timer.Seconds.ToString());
        }
        else
        {
			time = String.Concat(time, ":", timer.Seconds.ToString());
		}

        timerText.text = time;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
	}

    public void QuitGame()
    {
        #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
	}
}
