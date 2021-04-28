using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceControl : MonoBehaviour
{
    public AudioSource[] g_SoundEffect;
    public static bool g_BoolEffect = true;
    public static float preVolume = 0.8f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        setVolume(preVolume);
    }

    // Update is called once per frame
    public void setVolume(float vol){
        preVolume = vol;
        if(!g_BoolEffect){
            foreach (var item in g_SoundEffect)
            {
                item.volume = 0;
            }
        }else{
            foreach (var item in g_SoundEffect)
            {
                item.volume = preVolume;
            }
        }
    }
    public void setEffect(){
        g_BoolEffect = !g_BoolEffect;
        setVolume(preVolume);
    }
}
