using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float bgmVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("FMOD Events")]
    public List<EventReference> bgmEvents; // List of FMOD event references for BGM

    private EventInstance currentBGMInstance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateVolumeSettings();
    }

    // Update FMOD volume settings
    private void UpdateVolumeSettings()
    {
        RuntimeManager.StudioSystem.setParameterByName("MasterVolume", masterVolume);
        RuntimeManager.StudioSystem.setParameterByName("BGMVolume", bgmVolume);
        RuntimeManager.StudioSystem.setParameterByName("SFXVolume", sfxVolume);
    }

    // Play background music
    public void PlayBGM(EventReference eventReference, bool loop = true)
    {
        StopBGM(); // Stop any currently playing BGM

        if (!bgmEvents.Contains(eventReference))
        {
            Debug.LogWarning($"BGM Event '{eventReference.Path}' not found!");
            return;
        }

        currentBGMInstance = RuntimeManager.CreateInstance(eventReference);
        if (loop)
        {
            currentBGMInstance.setParameterByName("Loop", 1);
        }
        currentBGMInstance.start();
    }

    // Play sound effect directly without central management
    public static void PlaySFX(EventReference eventReference)
    {
        EventInstance sfxInstance = RuntimeManager.CreateInstance(eventReference);
        sfxInstance.start();
        sfxInstance.release(); // Release the instance after playing
    }

    // Stop background music
    public void StopBGM()
    {
        if (currentBGMInstance.isValid())
        {
            currentBGMInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            currentBGMInstance.release();
        }
    }

    // Adjust volume dynamically
    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        UpdateVolumeSettings();
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        UpdateVolumeSettings();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        UpdateVolumeSettings();
    }
}
