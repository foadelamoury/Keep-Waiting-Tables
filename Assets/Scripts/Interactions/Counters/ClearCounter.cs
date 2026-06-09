using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    [SerializeField] Transform counterTopPoint;

    [SerializeField] ClearCounter secondClearCounter;

    [SerializeField] bool testing;

    KitchenObjects kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {

                kitchenObject.ClearCounter = secondClearCounter;
            }
        }
    }

    public void Interact()
    {
        if (kitchenObjectSO == null)
        {
            Transform kitchenObjectClone = Instantiate(kitchenObjectSO.prefab, counterTopPoint);

            kitchenObjectClone.GetComponent<KitchenObjects>().ClearCounter = this;


        }


    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObjects GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }


}
