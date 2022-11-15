using UnityEngine;
using TMPro;

public sealed class UICoinDisplayer : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI displayText;

    public void UpdateDisplayText( int value ) {
        displayText.SetText( value.ToString() );
    }
}