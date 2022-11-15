using UnityEngine;
using AsyncOperator.Extensions;

public sealed class PlayerAnimator : MonoBehaviour {
    private readonly static int SPEED_PARAM = Animator.StringToHash( "Speed" );

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;

    [SerializeField] private float dampTime;

    private void Update() {
        Vector2 v = Vector2.ClampMagnitude( playerMovement.MovementDirection, 1f );
        animator.SetFloat( SPEED_PARAM, v.magnitude, dampTime, Time.deltaTime );
    }
}