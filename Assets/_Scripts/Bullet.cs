using UnityEngine;

public sealed class Bullet : MonoBehaviour {
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed;

    [SerializeField] private LayerMask barrelMask;

    public void FireBullet( Vector3 direction ) {
        direction.Normalize();
        body.velocity = direction * speed;
    }

    private void OnCollisionEnter( Collision collision ) {
        if ( barrelMask == ( barrelMask | 1 << collision.gameObject.layer ) ) {
            Destroy( collision.gameObject );
            Destroy( gameObject );
        }
    }
}