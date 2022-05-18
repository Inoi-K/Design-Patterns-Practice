namespace Command_Pattern {
    public class NullCommand : ICommand {
        public void Execute() {}
        public void Undo() {}
    }
}
