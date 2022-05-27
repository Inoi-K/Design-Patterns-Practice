namespace Command {
    public class NullCommand : ICommand {
        public void Execute() {}
        public void Undo() {}
    }
}
