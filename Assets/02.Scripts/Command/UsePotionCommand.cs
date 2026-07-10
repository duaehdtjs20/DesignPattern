using UnityEngine;

namespace DesignPatterns.Command
{
    public class UsePotionCommand : ICommand
    {
        private PlayerUnit player;
        public UsePotionCommand(PlayerUnit player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.UsePotion();
            Debug.Log("potion Execute");
        }

        public void Undo()
        {
            player.RestorePotion();
            Debug.Log("potion Undo");
        }
    }
}
