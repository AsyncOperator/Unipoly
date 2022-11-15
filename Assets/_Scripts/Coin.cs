using System;
using UnityEngine;

public sealed class Coin : MonoBehaviour {
    [SerializeField] private LayerMask playerMask;

    public event Action OnCollected;

    private void OnEnable() => CoinManager.Instance?.Add( this );

    private void OnDisable() => CoinManager.Instance?.Remove( this );

    private void OnTriggerEnter( Collider other ) {
        if ( playerMask == ( playerMask | 1 << other.gameObject.layer ) ) {
            OnCollected?.Invoke();
            Destroy( gameObject );
        }
    }
}