using System.Collections.Generic;

namespace Command {
    public class CommandHistory {
        Stack<ICommand> commandsBuffer = new ();

        public void Push(ICommand command) {
            commandsBuffer.Push(command);
        }

        public ICommand Pop() {
            return commandsBuffer.Count == 0 ? null : commandsBuffer.Pop();
        }
    }
}
