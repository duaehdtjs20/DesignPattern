using UnityEngine;
namespace DesignPatterns.Command
{
    public class CommandInput : MonoBehaviour
    {
        [SerializeField] private PlayerUnit player;
        [SerializeField] private EnemyUnit enemy;

        [Header("이동 키")]
        [SerializeField] private KeyCode forwardKey = KeyCode.W;
        [SerializeField] private KeyCode backKey = KeyCode.S;
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;

        [Header("행동 키")]
        [SerializeField] private KeyCode attackKey = KeyCode.Space;
        [SerializeField] private KeyCode potionKey = KeyCode.H;
        [SerializeField] private KeyCode undoKey = KeyCode.U;
        [SerializeField] private KeyCode redoKey = KeyCode.R;

        private void Update()
        {
            // 이동
            if (Input.GetKeyDown(forwardKey)) TryMove(Vector3.forward);
            if (Input.GetKeyDown(backKey)) TryMove(Vector3.back);
            if (Input.GetKeyDown(leftKey)) TryMove(Vector3.left);
            if (Input.GetKeyDown(rightKey)) TryMove(Vector3.right);

            if (Input.GetKeyDown(attackKey)) Attack(); // 공격
            if (Input.GetKeyDown(potionKey)) UsePotion(); // 포션

            if (Input.GetKeyDown(undoKey)) CommandInvoker.UndoCommand();
            if (Input.GetKeyDown(redoKey)) CommandInvoker.RedoCommand();
        }
        private void TryMove(Vector3 direction)
        {
            if (player == null) return;
            if(!player.IsValidMove(direction))
            {
                Debug.Log("이동불가. 장애물이 있다");
                return;
            }
            ICommand command = new MoveCommand(player, direction);
            CommandInvoker.ExecuteCommand(command);
        }
        private void Attack()
        {
            if (player == null || enemy == null)
            {
                return;
            }
            ICommand command = new AttackCommand(player, enemy);
            CommandInvoker.ExecuteCommand(command);
        }
        private void UsePotion()
        {
            if (player == null) return;
            if (!player.CanUsePotion())
            {
                return;
            }
            ICommand command = new UsePotionCommand(player);
            CommandInvoker.ExecuteCommand(command);
        }
    }
}
