using UnityEngine;

namespace DesignPatterns.StatePattern
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent (typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private float jumpPower = 6.0f;
        [SerializeField] private float gravity = -20.0f;
        [SerializeField] private float groundedRadius = 0.3f;
        [SerializeField] private float groundedOffset = -0.9f;
        [SerializeField] private LayerMask groundLayers;

        private CharacterController characterController;
        private SimplePlayerStateMachine playerStateMachine;
        private bool isGrounded;
        private float verticalVelocity;

        public bool IsGrounded => isGrounded;
        public Vector3 InputVector => playerInput.InputVector;
        public CharacterController CharacterController => characterController;
        public SimplePlayerStateMachine PlayerStateMachine => playerStateMachine;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            characterController = GetComponent<CharacterController>();
            playerStateMachine = new SimplePlayerStateMachine(this);
        }
        private void Start()
        {
            playerStateMachine.Initialize(playerStateMachine.IdleState);
        }

        void Update()
        {
            playerStateMachine.Excute();
            CheckGround();
            JumpAndGravity();
            Move();
        }
        private void Move()
        {
            Vector3 moveDirection = playerInput.InputVector.normalized;

            Vector3 horizontalMove = moveDirection * moveSpeed;
            Vector3 verticalMove = Vector3.up * verticalVelocity;
            characterController.Move((horizontalMove + verticalMove) * Time.deltaTime);
        }
        private void JumpAndGravity()
        {
            if(isGrounded && verticalVelocity < 0.0f)
            {
                verticalVelocity = -1.0f;
            }
            if(isGrounded && playerInput.IsJumping)
            {
                verticalVelocity = jumpPower;
                playerInput.IsJumping = false;
            }
            verticalVelocity += gravity * Time.deltaTime;
        }
        private void CheckGround()
        {
            Vector3 checkPosition = transform.position + Vector3.up * groundedOffset;

            isGrounded = Physics.CheckSphere(checkPosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
        }
    }
}
