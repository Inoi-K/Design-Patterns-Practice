using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioLibrary : MonoBehaviour {
    [SerializeField] AudioGroup[] audioGroups;

    Dictionary<AudioType, AudioClip[]> groupDictionary = new ();

    private void Awake() {
        foreach (AudioGroup soundGroup in audioGroups) {
            groupDictionary.Add(soundGroup.groupType, soundGroup.group);
        }
    }

    public AudioClip GetClipFromType(AudioType clipType) {
        if (groupDictionary.ContainsKey(clipType)) {
            AudioClip[] audios = groupDictionary[clipType];
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
        public AudioType groupType;
        public AudioClip[] group;
    }
}
