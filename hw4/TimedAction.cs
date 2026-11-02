using UnityEngine;
using UnityEngine.Events;

public class TimedAction : MonoBehaviour
{
    [Tooltip("The countdown length, in seconds.")]
    public float duration = 5.0f;
    [Tooltip("Whether the countdown should start automatically when the object is created.")]
    public bool startOnAwake = false;
    [Tooltip("Whether the countdown should repeat after it finishes.")]
    public bool repeat = false;
    [Tooltip("How many times the countdown should repeat. 0 means infinite.")]
    public int repeatCount = 0;
    [Tooltip("What happens each time the countdown finishes.")]
    public UnityEvent onTimerComplete;

    private float elapsedTime = 0.0f;
    private bool timerRunning = false;
    private int currentRepeatCount = 0;

    public void StartTimer()
    {
        timerRunning = true;
        elapsedTime = 0.0f;
    }
    public void StopTimer()
    {
        timerRunning = false;
    }

    void Start()
    {
        if (startOnAwake)
        {
            StartTimer();
        }
    }
    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= duration)
            {
                onTimerComplete.Invoke();
                elapsedTime = 0.0f;
                if(repeat && (currentRepeatCount < repeatCount || repeatCount == 0))
                {
                    currentRepeatCount++;
                }
                else
                {
                    StopTimer();
                }
                
            }
        }
    }
}
