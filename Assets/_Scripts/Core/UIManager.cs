using UnityEngine;
using AsyncOperator.Singleton;

public sealed class UIManager : Singleton<UIManager> {
    [SerializeField] private UICoinDisplayer uiCoinDisplayer;

    public void UpdateCoinDisplayer( int amount ) {
        uiCoinDisplayer.UpdateDisplayText( amount );
    }
}