using UnityEngine;

namespace DesignPatterns.Command
{
    // 플레이어의 이동명령
    // Execute()하면 플레이어가 이동
    // Undo()하면 반대방향으로 돌아간다.
    // 이 클래스는 입력을 받지 X
    // 오로지 이동명령 자체만 담당
    public class MoveCommand : ICommand
    {
        PlayerUnit player;
        private Vector3 direction; // 방향
        public MoveCommand(PlayerUnit player, Vector3 direction)
        {
            this.player = player;
            this.direction = direction;
        }
        // 이동명령을 실행
        public void Execute()
        {
            // 플레이어 이동 시킴
            player.Move(direction);
            Debug.Log("Move Execute : " + direction);
        }
        // 이동명령 되돌리기
        public void Undo()
        {
            player.Move(-direction);
            Debug.Log("Move Execute : " + -direction);
        }
    }
}
