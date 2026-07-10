using UnityEngine;

/*
[커맨드 패턴]

일반적인 코드
Input.GetKeyDown(Keycode.Space) -> Player.Attack(); -> 입력과 행동이 연결되어 있음

커맨드 패턴
Input.GetKeyDown(Keycode.Space) -> AttackCommand 생성 -> CommandInvoker.ExcuteCommand() -> player.Attack(); -> 입력과 행동이 분리

Concrete Command
- 실제 명령 클래스
- MoveCommand
- AttackCommand

Receiver
- 실제 작업을 수행하는 객체
- Player
- Enemy
...

Invoker
- 명령을 실행하는 관리자.

[왜 쓰냐?]
1. 입력과 행동을 분리할 수 있음
2. Undo / Redo 구현이 쉽다.

*/
namespace DesignPatterns.Command
{
    public interface ICommand
    {
        void Execute(); // 명령 실행
        void Undo(); // 실행했던 명령을 되돌린다.

    }

}
