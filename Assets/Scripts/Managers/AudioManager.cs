using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    #region FMOD_events
    [Header("Music")]
    [FMODUnity.EventRef] public string explorationMusicRef = "";
    [FMODUnity.EventRef] public string stairsMusicRef = "";
    [FMODUnity.EventRef] public string ascendMusicRef = "";
    [FMODUnity.EventRef] public string unlockMusicRef = "";

    [Header("SFX")]
    [FMODUnity.EventRef] public string stairsTurningSFXRef = "";
    [FMODUnity.EventRef] public string interactSFXRef = "";
    [FMODUnity.EventRef] public string pickupSFXRef = "";

    private EventInstance explorationMusic;
    private EventInstance stairsMusic;
    private EventInstance ascendMusic;
    private EventInstance unlockMusic;

    [HideInInspector] public EventInstance stairsTurningSFX;
    [HideInInspector] public EventInstance interactSFX;
    [HideInInspector] public EventInstance pickupSFX;

    private Dictionary<AudioType, EventInstance> audioEvents;
    #endregion

    bool coroutineRunning = false;
    bool inOrOut;
    IEnumerator coroutine;

    FMOD.Studio.PARAMETER_ID fadeParameterId;
    float faderLevel = 1.0f;

    public bool bankLoaded = false;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Start()
    {

        yield return new WaitUntil(() => FMODUnity.RuntimeManager.HasBankLoaded("Master"));
        bankLoaded = true;

        explorationMusic = FMODUnity.RuntimeManager.CreateInstance(explorationMusicRef);
        stairsMusic = FMODUnity.RuntimeManager.CreateInstance(stairsMusicRef);
        ascendMusic = FMODUnity.RuntimeManager.CreateInstance(ascendMusicRef);
        unlockMusic = FMODUnity.RuntimeManager.CreateInstance(unlockMusicRef);

        stairsTurningSFX = FMODUnity.RuntimeManager.CreateInstance(stairsTurningSFXRef);
        interactSFX = FMODUnity.RuntimeManager.CreateInstance(interactSFXRef);
        pickupSFX = FMODUnity.RuntimeManager.CreateInstance(pickupSFXRef);

        audioEvents = new Dictionary<AudioType, EventInstance>()
        {
            {AudioType.MUSIC_EXPLORE, explorationMusic },
            {AudioType.MUSIC_STAIRS, stairsMusic },
            {AudioType.MUSIC_ASCEND, ascendMusic },
            {AudioType.MUSIC_UNLOCK, unlockMusic },
            {AudioType.SFX_STAIRS_TURN, stairsTurningSFX },
            {AudioType.SFX_PICKUP, pickupSFX },
            {AudioType.SFX_INTERACT, interactSFX }
        };

        //PlayMusic(AudioType.MUSIC_EXPLORE);


        
        FMOD.Studio.EventDescription fadeEventDescription;
        audioEvents[AudioType.MUSIC_EXPLORE].getDescription(out fadeEventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION fadeParameterDescription;
        fadeEventDescription.getParameterDescriptionByName("VolumeFade", out fadeParameterDescription);
        fadeParameterId = fadeParameterDescription.id;
        float currentFadeValue;
        audioEvents[AudioType.MUSIC_EXPLORE].getParameterByID(fadeParameterId, out currentFadeValue);


        //StartFade(AudioType.MUSIC_STAIRS, true);
    }

    private void Update()
    {
        if (bankLoaded)
        {
            audioEvents[AudioType.MUSIC_EXPLORE].setParameterByID(fadeParameterId, faderLevel);
        }
    }

    public void StartFade(AudioType _track, bool _in)
    {
        if (IsPlaying(AudioType.MUSIC_ASCEND) || IsPlaying(AudioType.MUSIC_STAIRS))
        {
            if(_in)
                return;
        }

        if (!IsPlaying(_track))
        {
            if (_in)
            {
                PlayAudio(_track);
            }
            return;
        }

        if (_in != inOrOut && coroutine!=null)
        {
            StopCoroutine(coroutine);
            coroutineRunning = false;
        }
        inOrOut = _in;
        if (coroutineRunning)
        {
            Debug.Log("coroutine already running");
            return;
        }
            
        coroutine = FadeVolume(_track, _in);
        StartCoroutine(coroutine);
    }

    public void PlayAudio(AudioType _track)
    {
        if (!IsPlaying(_track))
        {
            audioEvents[_track].start();
        }
    }

    public void StopAudio(AudioType _track)
    {
        if (IsPlaying(_track))
        {
            audioEvents[_track].stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    private bool IsPlaying(AudioType _track)
    {
        PLAYBACK_STATE playbackState;
        audioEvents[_track].getPlaybackState(out playbackState);

        if (playbackState == PLAYBACK_STATE.PLAYING)
        {
            Debug.Log("selected audio already playing");
            return true;
        }
        return false;
    }

    private IEnumerator FadeVolume(AudioType _track, bool _in)
    {
        if (coroutineRunning)
        {
            coroutineRunning = false;
            yield break;
        }
        coroutineRunning = true;

        PLAYBACK_STATE playbackState;
        audioEvents[_track].getPlaybackState(out playbackState);

        if (playbackState == PLAYBACK_STATE.STOPPED)
        {
            Debug.Log("selected audio not playing");
            yield break;
        }

        
        

        float fadeLength = 3.0f;

        if (_in)
        {
            while(faderLevel<1f)
            {
                faderLevel += 0.01f / fadeLength;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (!_in)
        {
            while (faderLevel > 0f)
            {
                faderLevel -= 0.01f / fadeLength;
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineRunning = false;
    }

}