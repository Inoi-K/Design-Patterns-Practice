public class Comedian : TheaterActor {
    TheaterActor facingActor;

    string slappedLine;
    string idleLine;

    void OnEnable() {
        slappedLine = $"{nickname} was slapped, so he slaps {facingActor.nickname}";
        idleLine = $"{nickname} was not slapped, so he does nothing";
    }

    public void Face(TheaterActor actor) {
        facingActor = actor;
    }
    
    public override void React() {
        if (currentSlapped)
            facingActor.GetSlapped();
        
        PrintInfo(currentSlapped);
    }

    void PrintInfo(bool isSlapped) {
        print(isSlapped ? slappedLine : idleLine);
    }
}
