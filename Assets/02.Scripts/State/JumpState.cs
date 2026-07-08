using UnityEngine;

namespace DesignPatterns.StatePattern
{

    public class JumpState : IState
    {
        private PlayerController player;
        private Color meshColor = Color.red;

        public Color MeshColor
        {
            get => meshColor;
            set => meshColor = value;
        }
        public JumpState(PlayerController player)
        {
            this.player = player;
        }
        public void Enter()
        {
            // 점프 애니메이션을 재생
        }

        public void Excute()
        {
            if (!player.IsGrounded) return;

            if (player.InputVector != Vector3.zero)
            {
                // Walk상태로 전환
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.WalkeState);
            }
            else
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.IdleState);
            }
        }

        public void Exit()
        {
        }
    }
}
