using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    public Sound[] sounds;
    private Sound[] copysounds;
    AudioSource source;
    public AudioMixerGroup musicMixerGroup;
    public AudioMixerGroup masterMixerGroup;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        copysounds = sounds;
        //source.outputAudioMixerGroup = audioMixerGroup;
        

    }

    void Update()
    {
        if (copysounds.Length == 0)
        {
            copysounds = sounds;
        }
        //StartCoroutine(playAudioSequentially());
        if (!source.isPlaying)
        {
            PlayRandom();
        }

        
    }

    public void PlayRandom()
    {
        //AudioMixerGroup[] audiogroup = mixer.FindMatchingGroups("Music");
        source.outputAudioMixerGroup = musicMixerGroup;
        //source.outputAudioMixerGroup = 
        Sound s = copysounds[Random.Range(0, copysounds.Length)];
        source.clip = s.clip;
        
        source.Play();

        copysounds = copysounds.Where(snd => snd != s).ToArray();
    }


    IEnumerator playAudioSequentially()
    {
        yield return null;

        for (int i = 0; i < sounds.Length; i++)
        {
            source.clip = sounds[i].clip;

            source.Play();

            while (source.isPlaying)
            {
                yield return null;
            }

        }
    }

}
