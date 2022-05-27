namespace Command {
    public class LightOffCommand : ICommand {
        LightArea lightArea;
        float previousIntensityRatio;
    
        public LightOffCommand(LightArea lightArea) {
            this.lightArea = lightArea;
        }

        public void Execute() {
            previousIntensityRatio = lightArea.GetIntensityRatio();
        
            lightArea.SetIntensityRatio(0);
        }

        public void Undo() {
            lightArea.SetIntensityRatio(previousIntensityRatio);
        }
    }
}
