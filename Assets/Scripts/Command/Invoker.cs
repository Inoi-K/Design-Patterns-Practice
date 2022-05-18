using System;
using UnityEngine;

public class Invoker : MonoBehaviour {
    [SerializeField] ActorController actor;
    [SerializeField] LightArea lightArea;

    CommandHistory history = new ();

    void Update() {
        ICommand command = HandleKeyboardInput();
        if (command != null)
            ExecuteCommand(command);
    }

    void ExecuteCommand(ICommand command) {
        command.Execute();
        history.Push(command);
    }
    
    void Undo() {
        ICommand command = history.Pop();
        command?.Undo();
    }
    
    #region InputHandling
    ICommand HandleKeyboardInput() {
        if (Input.GetKeyDown(KeyCode.W)) return new MoveActorCommand(actor, 0, 1);
        if (Input.GetKeyDown(KeyCode.A)) return new MoveActorCommand(actor, -1, 0);
        if (Input.GetKeyDown(KeyCode.S)) return new MoveActorCommand(actor, 0, -1);
        if (Input.GetKeyDown(KeyCode.D)) return new MoveActorCommand(actor, 1, 0);

        return null;
    }
    
    public void ClickOn() {
        ICommand command = new LightOnCommand(lightArea);
        ExecuteCommand(command);
    }

    public void ClickOff() {
        ICommand command = new LightOffCommand(lightArea);
        ExecuteCommand(command);
    }

    public void ClickRandomColor() {
        ICommand command = new LightRandomCommand(lightArea);
        ExecuteCommand(command);
    }

    public void ClickUndo() {
        Undo();
    }
    #endregion
}
