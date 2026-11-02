using UnityEngine;
using UnityEngine.Events;

public class OnTriggerAction : MonoBehaviour
{
    [Tooltip("Only objects with this tag will trigger the events.")]
    public string triggerTagName = "MainCamera";
        [Tooltip("What happens when a matching object enters the trigger.")]
    public UnityEvent onEnter;
    [Tooltip("What happens when a matching object exits the trigger.")]
    public UnityEvent onExit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTagName))
        {
            onExit.Invoke();
        }
    }


}
