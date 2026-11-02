using UnityEngine;
using UnityEngine.Events;

public class CollideAction : MonoBehaviour
{
    [Tooltip("Only objects with this tag will trigger the events.")]
    public string colliderTagName = "MainCamera";
    [Tooltip("What happens when a matching object collides with this object.")]
    public UnityEvent onCollision;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(colliderTagName))
        {
            onCollision.Invoke();
        }
    }

}
