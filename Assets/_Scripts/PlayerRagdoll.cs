using UnityEngine;

public sealed class PlayerRagdoll : MonoBehaviour {
    [SerializeField] private Transform playerRagdollPf;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private UICountdownTimer uiCountdownTimer;

    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;

    private void OnEnable() => uiCountdownTimer.OnTimeElapsed += CreateRagdoll;

    private void OnDisable() => uiCountdownTimer.OnTimeElapsed -= CreateRagdoll;

    private void CreateRagdoll() {
        Transform ragdoll = Instantiate<Transform>( playerRagdollPf );
        MatchAllChildTransforms( playerTransform, ragdoll );
        ApplyExplosionForceToRagdoll( ragdoll, ragdoll.position + Random.insideUnitSphere, explosionForce, explosionRadius );
        Destroy( playerTransform.gameObject );
    }

    private void MatchAllChildTransforms( Transform root, Transform clone ) {
        foreach ( Transform child in root ) {
            Transform cloneChild = clone.Find( child.name );
            if ( cloneChild != null ) {
                cloneChild.SetPositionAndRotation( child.position, child.rotation );
                MatchAllChildTransforms( child, cloneChild );
            }
        }
    }

    private void ApplyExplosionForceToRagdoll( Transform root, Vector3 position, float force, float radius ) {
        foreach ( Transform child in root ) {
            if ( child.TryGetComponent( out Rigidbody body ) ) {
                body.AddExplosionForce( force, position, radius );
            }
            ApplyExplosionForceToRagdoll( child, position, force, radius );
        }
    }
}