using UnityEngine;

public class LightRandomCommand : ICommand {
    LightArea lightArea;

    Color previousColor;
    
    public LightRandomCommand(LightArea lightArea) {
        this.lightArea = lightArea;
    }

    public void Execute() {
        previousColor = lightArea.GetColor();
        
        Color randomColor = Random.ColorHSV();
        lightArea.SetColor(randomColor);
    }

    public void Undo() {
        lightArea.SetColor(previousColor);
    }
}
