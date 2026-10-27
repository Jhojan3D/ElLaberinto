using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource sfxUiSource;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        musicSource = transform.Find("MusicSource").GetComponent<AudioSource>();
        sfxSource = transform.Find("SfxSource").GetComponent<AudioSource>();
        sfxUiSource = transform.Find("SfxUiSource").GetComponent<AudioSource>();
    }
    public void PlayMusic(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }
    public void PlaySfx(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }
    public void PlaySfxUi(AudioClip audioClip)
    {
        sfxUiSource.PlayOneShot(audioClip);
    }
}
