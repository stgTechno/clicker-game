using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;

    private static BackgroundMusicScript _instance;

    public int trackSelector;
    public int trackHistory;

    public AudioSource[] tracks;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        tracks = new AudioSource[] { track1, track2, track3 };
        PlayMusic();
    }

    private void Update()
    {
        if (!tracks[trackSelector].isPlaying && !AudioListener.pause)
        {
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        var previousTrack = trackSelector;

        do
        {
            trackSelector = Random.Range(0, tracks.Length);
        } while (previousTrack == trackSelector && tracks[previousTrack].isPlaying);

        tracks[previousTrack].Stop();
        tracks[trackSelector].Play();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        AudioListener.pause = !hasFocus;
    }
}
