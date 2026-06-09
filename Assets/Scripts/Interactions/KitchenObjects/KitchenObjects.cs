using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public ClearCounter ClearCounter
    {
        get
        {
            return clearCounter;
        }
        set
        {
            if (this.clearCounter != null)
            {
                this.clearCounter.ClearKitchenObject();

            }
            this.clearCounter = value;

            if (value != null)
            {
                if (value.HasKitchenObject())
                {
                    Debug.LogError("Counter already has a Kitchen Object!");
                }
                value.SetKitchenObject(this);
                transform.parent = value.GetKitchenObjectFollowTransform();
                transform.localPosition = Vector3.zero;
            }
        }
    }

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }



}
