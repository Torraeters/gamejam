using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public AudioClip audioSourceLoop;
    public AudioClip audioSourceIntro;
    public AudioSource src;

    public bool isPlaying;

    void Start()
    {
    }

    IEnumerator playEngineSound()
    {
        src.clip = audioSourceIntro;
        src.loop = true;
        src.Play();
        yield return new WaitForSeconds(src.clip.length);
        src.clip = audioSourceLoop;
        src.Play();
    }

    public void play()
    {
        isPlaying = true;
        StartCoroutine(playEngineSound());
    }

    public void stop() {
        isPlaying = false;
        src.Stop();
    }
}
