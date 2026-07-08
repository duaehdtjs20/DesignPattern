using System;

namespace DesignPatterns.StatePattern
{
    // 현재 상태를 저장
    // 상태 전환을 담당
    // 현재 상태의 Excute()를 싱행
    // 상태가 바뀌면 stateChanged 이벤트를 발생시킴
    [Serializable]
    public class SimplePlayerStateMachine
    {
        public IState CurrentState { get; private set; } // 현재 실행중인 상태
        public WalkState WalkeState { get; private set; } // 걷기 상태 객체
        public JumpState JumpState { get; private set; } // 점프
        public IdleState IdleState { get; private set; } // 대기

        // 상태가 바뀔때 실행되는 이벤트
        public event Action<IState> stateChanged;

        public SimplePlayerStateMachine(PlayerController player)
        {
            WalkeState = new WalkState(player);
            JumpState = new JumpState(player);
            IdleState = new IdleState(player);
        }
        public void Initialize(IState state)
        {
            CurrentState = state; // 전달받은 상태를 현재 상태로 저장

            // 현재 상태의 Enter를 실행
            CurrentState.Enter();

            // 상태가 변경되었다는 이벤트를 발생
            stateChanged?.Invoke(CurrentState);
        }
        public void TransitionTo(IState nextState)
        {
            // 현재 상태와 다음 상태가 같으면 아무것도 하지 말자
            if (CurrentState == nextState) return;

            // 현재 상태를 종료
            CurrentState.Exit();
            // 다음 상태를 현재로 변경해준다.
            CurrentState = nextState;
            // 새로운 상태에 진입
            CurrentState.Enter();

            stateChanged?.Invoke(CurrentState);
        }
        public void Excute()
        {
            if(CurrentState == null) return;
            CurrentState.Excute();
        }
    }
}
