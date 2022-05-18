using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    [SerializeField] AudioLibrary musicLibrary;
    [SerializeField] AudioLibrary soundLibrary;

    public void PlayRandomMusic() {
        PlayAudioFrom(musicLibrary.GetRandomClip(), musicSource);
    }
    
    void PlayMusic(string musicName) {
        PlayAudioFrom(musicLibrary.GetClipFromName(musicName), musicSource);
    }
    
    public void PlaySound(string soundName) {
        PlayAudioFrom(soundLibrary.GetClipFromName(soundName), sfxSource);
    }

    void PlayAudioFrom(AudioClip clip, AudioSource source) {
        if (clip == null)
            return;
        
        source.clip = clip;
        source.Play();
    }
}
