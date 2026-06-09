using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
    [SerializeField] Transform counterTopPoint;

    public void Interact()
    {

        Transform kitchenObjectClone = Instantiate(kitchenObjectSO.prefab, counterTopPoint);

        kitchenObjectClone.localPosition = Vector3.zero;
    }
}
