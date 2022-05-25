using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    [SerializeField] AudioLibrary musicLibrary;
    [SerializeField] AudioLibrary soundLibrary;

    public void PlayRandomMusic() {
        PlayAudioFrom(musicLibrary.GetRandomClip(), musicSource);
    }
    
    public void PlayMusic(AudioType musicType) {
        PlayAudioFrom(musicLibrary.GetClipFromType(musicType), musicSource);
    }

    public void PlayRandomSound() {
        PlayAudioFrom(soundLibrary.GetRandomClip(), sfxSource);
    }
    
    public void PlaySound(AudioType soundType) {
        PlayAudioFrom(soundLibrary.GetClipFromType(soundType), sfxSource);
    }

    void PlayAudioFrom(AudioClip clip, AudioSource source) {
        if (clip == null)
            return;
        
        source.clip = clip;
        source.Play();
    }
}
