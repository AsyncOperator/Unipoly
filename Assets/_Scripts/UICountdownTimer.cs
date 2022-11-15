using UnityEngine;
using TMPro;
using System;

public sealed class UICountdownTimer : MonoBehaviour {
    private const string FORMAT = "0.00";

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int seconds;

    private float remainingTime;
    private bool isTimeElapsed;

    public event Action OnTimeElapsed;

    private void Start() => remainingTime = seconds;

    private void Update() {
        if ( isTimeElapsed )
            return;

        remainingTime = Mathf.Max( 0f, remainingTime - Time.deltaTime );
        if ( Mathf.Approximately( 0f, remainingTime ) ) {
            isTimeElapsed = true;
            OnTimeElapsed?.Invoke();
        }
        UpdateTimerText();
    }

    private void UpdateTimerText() {
        timerText.SetText( remainingTime.ToString( FORMAT ) );
    }
}