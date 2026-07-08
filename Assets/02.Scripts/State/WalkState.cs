using UnityEngine;

namespace DesignPatterns.StatePattern
{
    public class WalkState : IState
    {

        private PlayerController player;
        private Color meshColor = Color.blue;

        public Color MeshColor
        {
            get => meshColor;
            set => meshColor = value;
        }
        public WalkState(PlayerController player)
        {
            this.player = player;
        }
        public void Enter()
        {
            // 걷기 애니메이션을 재생
        }

        public void Excute()
        {
            if (!player.IsGrounded)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.JumpState);
                return;
            }
            if(player.InputVector == Vector3.zero)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.IdleState);
            }
        }

        public void Exit()
        {
            // 걷는 애니메이션 종료...
        }
    }
}
