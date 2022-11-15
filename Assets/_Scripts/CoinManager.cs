using System.Collections.Generic;
using UnityEngine;
using AsyncOperator.Singleton;

[DefaultExecutionOrder( -10 )]
public sealed class CoinManager : Singleton<CoinManager> {
    private readonly List<Coin> Coins = new();

    private int collectedCoinAmount = 0;

    private void Start() => UIManager.Instance.UpdateCoinDisplayer( collectedCoinAmount );

    public void Add( Coin coin ) {
        Coins.Add( coin );
        coin.OnCollected += UpdateCollectedCoinAmount;
    }

    public void Remove( Coin coin ) {
        Coins.Remove( coin );
        coin.OnCollected -= UpdateCollectedCoinAmount;
    }

    private void UpdateCollectedCoinAmount() {
        collectedCoinAmount++;
        UIManager.Instance.UpdateCoinDisplayer( collectedCoinAmount );
    }

    // To visualize all coins in the scene
    private void OnDrawGizmos() {
        if ( Coins.Count == 0 )
            return;

        Vector3 from = transform.position;
        foreach ( Coin coin in Coins ) {
            Gizmos.DrawLine( from, coin.transform.position );
        }
    }
}