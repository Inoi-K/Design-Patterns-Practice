public class LightOnCommand : ICommand {
    LightArea lightArea;
    float previousIntensityRatio;
    
    public LightOnCommand(LightArea lightArea) {
        this.lightArea = lightArea;
    }

    public void Execute() {
        previousIntensityRatio = lightArea.GetIntensityRatio();
        
        lightArea.SetIntensityRatio(1);
    }

    public void Undo() {
        lightArea.SetIntensityRatio(previousIntensityRatio);
    }
}
