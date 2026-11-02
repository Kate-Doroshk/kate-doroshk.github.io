using UnityEngine;
using UnityEngine.Events;

public class SequenceAction : MonoBehaviour
{
    [Tooltip("The actions to run, in order.")]
    public UnityEvent[] steps;
    [Tooltip("The delay, in seconds, before each step is executed. Counted from when the previous step fired. ")]
    public float[] stepDelays;
    int currentStep = 0;
    float elapsedTime = 0.0f;
    bool sequenceRunning = false;

    public void StartSequence()
    {
        elapsedTime = 0.0f;
        currentStep = 0;
        sequenceRunning = true;
    }

    public void StopSequence()
    {
        sequenceRunning = false;
    }

    void Update()
    {
        if (sequenceRunning)
        {
            elapsedTime += Time.deltaTime;
            if (currentStep < steps.Length && elapsedTime >= stepDelays[currentStep])
            {
                steps[currentStep].Invoke();
                currentStep++;
                elapsedTime = 0.0f;
            }
            else if (currentStep >= steps.Length)
            {
                StopSequence();
            }
        }
    }


}
