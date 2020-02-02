using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public AudioClip audioSourceLoop;
    public AudioClip audioSourceIntro;
    public AudioSource src;

    void Start()
    {
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        src.clip = audioSourceIntro;
        src.Play();
        yield return new WaitForSeconds(src.clip.length);
        src.clip = audioSourceLoop;
        src.Play();
    }
}
