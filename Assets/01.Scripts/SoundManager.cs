using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource BGMsource;
    [SerializeField] AudioSource SFXsource;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }

    public void SetBGMVolume(float volume)
    {
        BGMsource.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        SFXsource.volume=volume;
    }

}
