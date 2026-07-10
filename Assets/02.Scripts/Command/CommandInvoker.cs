using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    // 명령을 실행하고 기록하는 녀석
    public static class CommandInvoker
    {
        private static Stack<ICommand> undoStack = new Stack<ICommand>();
        private static Stack<ICommand> redoStack = new Stack<ICommand>();

        public static void ExecuteCommand(ICommand command)
        {
            if (command == null) return;
            command.Execute();
            undoStack.Push(command);
            redoStack.Clear();
        }
        public static void UndoCommand()
        {
            if (undoStack.Count <= 0)
            {
                return;
            }
            ICommand command = undoStack.Pop(); // 가장 최근에 실행한 명령을 꺼냄
            command.Undo(); // 해당 명령 되돌림
            redoStack.Push(command); // 되돌린 명령은 다시 실행할 수 있도록 RedoStack에 저장
        }
        public static void RedoCommand()
        {
            if(redoStack.Count <= 0)
            {
                return;
            }
            ICommand command = redoStack.Pop(); // 가장 최근에 Undo한 명령을 꺼낸다
            command.Execute();
            undoStack.Push(command);
        }
        public static void Clear()
        {
            undoStack.Clear();
            redoStack.Clear();
        }
    }
}
