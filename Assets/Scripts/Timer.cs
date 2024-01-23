using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;
    private int seconds;
    private int minutes;
    private int hours;
    private bool isStarted;

    public Action TimeChanged;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("The value must be greater than zero");
            }
            if (seconds + value > 59)
            {
                int temp = seconds + value;
                Minutes = temp / 60;
                seconds = temp % 60;
            }
            else
            {
                seconds += value;
            }
        }
    }
    public int Minutes
    { get { return minutes; }
        set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("The value must be greater than zero");
            }
            if (minutes + value > 59)
            {
                int temp = minutes + value;
                Hours = temp / 60;
                minutes = temp % 60;
            }
            else
            {
                minutes += value;
            }
        }
    }
    public int Hours
    {
        get { return hours; }
        set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("The value must be greater than zero");
            }
            if (value + hours > 23)
            {
                int temp = hours + value;
                hours = temp % 24;
            }
            else
            {
                hours += value;
            }
        }
    }


    private void FixedUpdate()
    {
        if (isStarted)
        {
            time += 0.02f;
            if (time >= 1f)
            {
                time = 0;
                Seconds = 1;
                TimeChanged?.Invoke();
            }
        }
    }
    
    public void StartTimer() => isStarted = true;
    public void StopTimer() => isStarted = false;
    public void ResetTimer() => hours = minutes = seconds = 0;
    public int GetTimeInSeconds() => hours*3600 + minutes*60 + seconds;
}
