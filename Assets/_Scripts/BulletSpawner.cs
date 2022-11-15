using UnityEngine;

public sealed class BulletSpawner : MonoBehaviour {
    [SerializeField] private Bullet bulletPf;
    [SerializeField] private PlayerMovement playerMovement;

    public void SpawnBullet() {
        if ( playerMovement == null )
            return;

        Vector3 direction = playerMovement.transform.forward;
        Vector3 spawnPosition = playerMovement.transform.position;
        spawnPosition += direction + Vector3.up;

        Bullet instance = Instantiate<Bullet>( bulletPf, spawnPosition, Quaternion.identity );
        instance.FireBullet( direction );
    }

    private void OnDrawGizmos() {
        if ( playerMovement == null )
            return;

        Vector3 direction = playerMovement.transform.forward;
        Vector3 spawnPosition = playerMovement.transform.position;
        spawnPosition += direction + Vector3.up;

        Gizmos.DrawSphere( spawnPosition, 0.1f );
    }
}