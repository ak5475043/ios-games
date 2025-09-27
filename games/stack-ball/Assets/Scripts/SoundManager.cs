using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource myAudioSource;
    public bool sound = true;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();    
        MakeSingleton();
    }
    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SoundOnOff()
    {
        sound = !sound;
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if(sound)
            myAudioSource.PlayOneShot(clip,volume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
