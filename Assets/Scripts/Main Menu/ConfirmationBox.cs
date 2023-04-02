using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmationBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI confirmationText;
    private System.Action confirmAction;
    private System.Action cancelAction;

    public void ShowConfirmationBox(string message, System.Action onConfirm, System.Action onCancel)
    {
        confirmationText.text = message;
        confirmAction = onConfirm;
        cancelAction = onCancel;
        gameObject.SetActive(true);
    }

    public void OnConfirmClicked()
    {
        confirmAction?.Invoke();
        gameObject.SetActive(false);
    }   

    public void OnCancelClicked()
    {
        cancelAction?.Invoke();
        gameObject.SetActive(false);
    }
}
