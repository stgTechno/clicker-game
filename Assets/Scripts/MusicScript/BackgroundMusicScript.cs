using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;

    public static BackgroundMusicScript instance;

    public int trackSelector;
    public int trackHistory;

    public AudioSource[] tracks;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tracks = new AudioSource[] { track1, track2, track3 };
        playMusic();
    }

    void Update()
    {
        if (!tracks[trackSelector].isPlaying && !AudioListener.pause)
        {
            playMusic();
        }
    }

    private void playMusic()
    {
        int previousTrack = trackSelector;

        do
        {
            trackSelector = Random.Range(0, tracks.Length);
        } while (previousTrack == trackSelector && tracks[previousTrack].isPlaying);

        tracks[previousTrack].Stop();
        tracks[trackSelector].Play();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        AudioListener.pause = !hasFocus;
    }
}
