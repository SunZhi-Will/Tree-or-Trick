using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsMusic : MonoBehaviour
{
    
    public AudioClip AttackEffectMusic;
    public AudioClip HitTreeEffectMusic;
    public AudioClip WinTreeMusic;
    public AudioClip WinChildMusic;

    static AudioSource EffectScene;

    static AudioClip[] EffectMusic = new AudioClip[10];
    
    // Start is called before the first frame update
    void Start()
    {
        EffectScene = GetComponent<AudioSource>();
        EffectMusic[0] = AttackEffectMusic;
        EffectMusic[1] = HitTreeEffectMusic;
        EffectMusic[2] = WinTreeMusic;
        EffectMusic[3] = WinChildMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void AudioAttack(){
        AudioEffMusic(EffectMusic[0]);
    }
    public static void AudioHitTree(){
        AudioEffMusic(EffectMusic[1]);
    }
    public static void AudioWinTree(){
        AudioEffMusic(EffectMusic[2]);
    }
    public static void AudioWinChild(){
        AudioEffMusic(EffectMusic[3]);
    }
    public static void AudioEffMusic(AudioClip _ac){
        if(VoiceControl.g_BoolEffect){
            EffectScene.PlayOneShot(_ac, VoiceControl.preVolume);
            
        }
    }
}
