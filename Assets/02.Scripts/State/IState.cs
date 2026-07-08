/*
상태패턴(State Pattern)
- 객체의 상태에 따라 동작을 변경하는 디자인 패턴

게임에서는 다음과 같은 상태가 존재한다.
Idle, Walke, Run, Jump, Attack, Die

- 상태 패턴을 쓰지 않은 경우
if(state == Idle) {...}
else if(state == Walk) {...}
else if(state == Run) {...}
else if(state == Jump) {...}
else if(state == Attack) {...}
else if(state == Die) {...}

만약 상태가 많아질수록 조건이 계속 늘어나게 된다.
ㄴ 코드가 복잡해지고 관리하기 어려워짐.

- 상태패턴을 적용
IdleState.cs
WaleState.cs
RunState.cs
JumpState.cs
AttackState.cs
DieState.cs

*/
namespace DesignPatterns.StatePattern
{
    public interface IState : Icolorable
    {
        // 상태에 처음 들어올 때 1번 실행(상태에 진입했을 때)
        void Enter();
        // 해당 상태가 유지되는 동안 실행
        void Excute();
        // 다른 상태로 바뀌기 직전에 1번 실행(상태에서 빠져나갈 때)
        void Exit();
    }
}
