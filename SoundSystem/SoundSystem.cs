using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    protected AudioSource audioSource;

    protected static SoundSystem _instance;
    public static SoundSystem Instance { get { return _instance; } }
    
    public AudioClip pointSfX;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            audioSource = _instance.gameObject.GetComponent<AudioSource>();
        }
    }
    
    public void PlayPointSFX()
    {
        PlaySound(pointSfX);
    }
    
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, 1f);
    }
}
