using UnityEngine;

public class Stage : MonoBehaviour {
    [SerializeField] TheaterActor[] actors;

    [SerializeField] int initialSlappedIndex;

    int currentFrame;
    const int FramesNumber = 6;
    
    // for the sake of saving time
    void OnEnable() {
        for (int i = 0; i < actors.Length; ++i) {
            if (actors[i] is Comedian) {
                ((Comedian)actors[i]).Face(actors[(i + 1) % actors.Length]);
            }
        }
    }

    void Start() {
        actors[initialSlappedIndex].GetSlapped();
    }

    void Update() {
        ++currentFrame;
        if (currentFrame > FramesNumber)
            return;
        
        foreach (TheaterActor actor in actors) {
            actor.React();
        }
        
        foreach (TheaterActor actor in actors) {
            actor.Swap();
        }
        
        print($"{currentFrame} STAGE FRAME UPDATE ENDS");
    }
}
