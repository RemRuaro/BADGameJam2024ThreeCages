using UnityEngine;

public class AudioManagerLevel02 : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _MusicSource;
    [SerializeField] private AudioSource _SoundEffectSource;

    [Header("Audio Clip")]
    public AudioClip _Background;
    public AudioClip _ChanclaThrow;
    public AudioClip _ChanclaImpact;
    public AudioClip _RaygonSpray;

    public void PlayBackgroundMusic()
    {
        _MusicSource.clip = _Background;
        _MusicSource.Play();
    }
}
