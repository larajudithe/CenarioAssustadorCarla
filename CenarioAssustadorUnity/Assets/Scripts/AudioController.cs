using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake ()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        StartCoroutine (PlaySFXCoroutine(audioClip, volume));
    }

    IEnumerator PlaySFXCoroutine(AudioClip audioClip, float volume = 1f)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return  new WaitForSeconds(audioSource.clip.length + 2);

        Destroy(audioSource);
    }
}
