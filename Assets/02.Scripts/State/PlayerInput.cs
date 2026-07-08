using UnityEngine;


namespace DesignPatterns.StatePattern
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private KeyCode forward = KeyCode.W;
        [SerializeField] private KeyCode back = KeyCode.S;
        [SerializeField] private KeyCode left = KeyCode.A;
        [SerializeField] private KeyCode right = KeyCode.D;
        [SerializeField] private KeyCode jump = KeyCode.Space;

        private Vector3 inputvector;
        public Vector3 InputVector => inputvector;

        private bool isJumping;
        public bool IsJumping
        {
            get => isJumping;
            set => isJumping = value;
        }
        private float xInput;
        private float yInput;
        private float zInput;

        void Update()
        {
            HandleInput();
        }
        public void HandleInput()
        {
            xInput = 0.0f;
            yInput = 0.0f;
            zInput = 0.0f;
            if (Input.GetKey(forward)) zInput++;
            if (Input.GetKey(back)) zInput--;
            if (Input.GetKey(left)) xInput--;
            if (Input.GetKey(right)) xInput++;

            inputvector = new Vector3(xInput, yInput, zInput);
            isJumping = Input.GetKeyDown(jump);
        }
    }
}

