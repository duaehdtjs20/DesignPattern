using Mono.Cecil.Cil;
using UnityEngine;

namespace DesignPatterns.StatePattern
{
    public class IdleState : IState
    {
        private PlayerController player;
        private Color meshColor = Color.white;

        public Color MeshColor
        {
            get => meshColor;
            set => meshColor = value;
        }
        public IdleState(PlayerController player)
        {
            this.player = player;
        }
        public void Enter()
        {
            // 대기 애니메이션을 재생
        }

        public void Excute()
        {
            if(!player.IsGrounded)
            {
                // 점프 상태로 전환
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.JumpState);
                return;
            }
            if(player.InputVector != Vector3.zero)
            {
                // Walk 상태로 전환
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.WalkeState);
            }
        }

        public void Exit()
        {
            // 대기 애니메이션 종료..
        }
    }
}
