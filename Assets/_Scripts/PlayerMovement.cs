using UnityEngine;
using UnityEngine.InputSystem;
using AsyncOperator.Extensions;

public sealed class PlayerMovement : MonoBehaviour {
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody body;

    [SerializeField, Range( 1f, 10f )] private float speed;
    [SerializeField] private float angularSpeed;

    public Vector2 MovementDirection { get; set; }

    private void Update() {
        MovementDirection = playerInput.actions[ "Move" ].ReadValue<Vector2>();
        if ( !Mathf.Approximately( MovementDirection.magnitude, 0f ) ) {
            transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( MovementDirection.XZ(), transform.up ), angularSpeed * Time.deltaTime );
        }
    }

    private void FixedUpdate() {
        body.MovePosition( body.position + MovementDirection.XZ() * speed * Time.fixedDeltaTime );
    }
}