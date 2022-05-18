using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioLibrary : MonoBehaviour {
    [SerializeField] AudioGroup[] audioGroups;

    Dictionary<string, AudioClip[]> groupDictionary = new ();

    private void Awake() {
        foreach (AudioGroup soundGroup in audioGroups) {
            groupDictionary.Add(soundGroup.groupID, soundGroup.group);
        }
    }

    public AudioClip GetClipFromName(string clipName) {
        if (groupDictionary.ContainsKey(clipName)) {
            AudioClip[] audios = groupDictionary[clipName];
            return audios[Random.Range(0, audios.Length)];
        }
        return null;
    }

    public AudioClip GetRandomClip() {
        AudioClip[] audios = groupDictionary.ElementAt(Random.Range(0, groupDictionary.Count)).Value;
        return audios[Random.Range(0, audios.Length)];
    }

    [System.Serializable]
    public class AudioGroup {
        public string groupID;
        public AudioClip[] group;
    }
}
