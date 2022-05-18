public class MoveActorCommand : ICommand {
    ActorController actor;
    int x, y;
    //int previousX, previousY;
    
    public MoveActorCommand(ActorController actor, int x, int y) {
        this.actor = actor;
        this.x = x;
        this.y = y;
        //previousX = 0;
        //previousY = 0;
    }

    public void Execute() {
        //previousX = -x;
        //previousY = -y;

        actor.Move(x, y);
    }

    public void Undo() {
        actor.Move(-x, -y);
        //actor.Move(previousX, previousY);
    }
}
