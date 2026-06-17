using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    public virtual void Interact(PlayerController playerController)
    {
        Debug.LogError("BaseCounter.Interact()");
    }
}
