using Unity.VisualScripting;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] ClearCounter clearCounter;

    [SerializeField] GameObject visualGameObject;

    private void Start()
    {
        PlayerController.Instance.OnSelectedCounterChanged += PlayerController_OnSelectedCounterChanged;

    }

    private void PlayerController_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    void Show() {  visualGameObject.SetActive(true);  }
    void Hide() { visualGameObject.SetActive(false);  }
}
