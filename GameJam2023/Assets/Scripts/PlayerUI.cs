
using System.Security.AccessControl;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Prefab = UnityEngine.GameObject;
using Text = UnityEngine.UI.Text;
using Image = UnityEngine.UI.Image;
using MathF = System.MathF;
using Vector3 = UnityEngine.Vector3;
using AudioSource = UnityEngine.AudioSource;



[System.Serializable]
public enum SoundID
{
    NORMAL_CLOCK,
    END_TIME_CLOCK,
    END_CLOCK,
    MENU_BUTTON,
    LETTER_CORRECT,
    LETTER_WRONG
}
[System.Serializable]
public enum SoundCategory
{
    CLOCK,
    GAME,
    UI
}


[System.Serializable]
public class SerializableSound
{
    [SerializeField]
    public SoundID ID;

    [SerializeField]
    public SoundCategory Category;

    [SerializeField]
    public AudioClip sound;

    [SerializeField]
    public bool loop;
}

[System.Serializable]
public class SoundsPlayer
{
    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public SoundCategory soundCategory;
}

[System.Serializable]
public class SerializableColor
{

    [SerializeField]
    public float[] colorStore = new float[4] { 1F, 1F, 1F, 1F };
    [SerializeField]
    public Color Color
    {
        get { return new Color(colorStore[0], colorStore[1], colorStore[2], colorStore[3]); }
        set { colorStore = new float[4] { value.r, value.g, value.b, value.a }; }
    }

    //makes this class usable as Color, Color normalColor = mySerializableColor;
    public static implicit operator Color(SerializableColor instance)
    {
        return instance.Color;
    }

    //makes this class assignable by Color, SerializableColor myColor = Color.white;
    public static implicit operator SerializableColor(Color color)
    {
        return new SerializableColor { Color = color };
    }
}

public class PlayerUI : MonoBehaviour
{

    [SerializeField]

    public Prefab ClockObject;

    [SerializeField]
    public TMP_Text ClockText;

    [SerializeField]
    public Image ClockFill;

    [SerializeField]
    public int currentClockTime;
    [SerializeField]
    public int maxClockTime = 0;

    private int currentTick;

    public AudioSource audioSource;


    [SerializeField] SerializableColor[] ClockColors;
    [SerializeField] SerializableSound[] Sounds;
    [SerializeField] SoundsPlayer[] SoundsPlayers;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        setupPlayerPrefs();
    }

    [SerializeField]
    private bool NORMAL_CLOCK = false;
    [SerializeField]
    private bool END_TIME_CLOCK = false;

    // Update is called once per frame
    public void FixedUpdate()
    {
        currentTick++;

        if (currentTick % 50 == 0 && maxClockTime > 0 && currentClockTime > 0)
        {
            currentClockTime--;
            updateClock(currentClockTime);
            if (currentClockTime == 0)
            {
                playSound(SoundID.END_CLOCK);
            }
            else
            {
                if (currentClockTime < maxClockTime / 4 && END_TIME_CLOCK == false)
                {
                    END_TIME_CLOCK = true;
                    stopSound(SoundID.NORMAL_CLOCK);
                    playSound(SoundID.END_TIME_CLOCK);
                }
                else if (NORMAL_CLOCK == false)
                {
                    NORMAL_CLOCK = true;
                    playSound(SoundID.NORMAL_CLOCK);
                }
            }
        }
        if (currentClockTime < maxClockTime / 4)
        {
            ClockText.color = new Color(0.0f, 0.0f, 0.0f, Mathf.Sin(Time.time * 10.0f));
        }
        else
        {
            ClockText.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public int getTime()
    {
        return currentClockTime;
    }

    public void StartClock(int time)
    {
        //enable clock
        ClockObject.SetActive(true);
        currentClockTime = time;
        maxClockTime = time;
    }

    public SerializableColor getColor()
    {
        //get amount of colors
        int colorAmount = ClockColors.Length;
        //get current color index in refeer of percent from maxClockTime and currentClockTime
        int colorIndex = (int)MathF.Floor((float)currentClockTime / (float)maxClockTime * (float)colorAmount);
        //return color
        //inverse colorIndex
        colorIndex = colorAmount - colorIndex - 1;
        return ClockColors[colorIndex];
    }

    public void updateClock(int time)
    {
        currentClockTime = time;
        ClockText.text = time.ToString() + "s";
        //make clock text blink if time is less than 25%

        ClockFill.color = getColor().Color;
        //set ClockFill FillAmount to currentClockTime / maxClockTime
        ClockFill.fillAmount = (float)currentClockTime / (float)maxClockTime;
        //inverse fillAmount
        ClockFill.fillAmount = 1.0f - ClockFill.fillAmount;
    }

    public void setInteractedGame(string gameName)
    {
        PlayerPrefs.SetString("InteractedGame", gameName);
    }

    public void setPlayerTime(int time)
    {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("InteractedGame") + ".Time", time);
    }

    public void getVolume(SoundCategory category)
    {
        float volume = PlayerPrefs.GetFloat(category.ToString() + ".Volume");
        audioSource.volume = volume;
    }

    public void setVolume(SoundCategory category, float volume)
    {
        PlayerPrefs.SetFloat(category.ToString() + ".Volume", volume);
        audioSource.volume = volume;
    }

    public void playSound(SoundID soundID)
    {
        foreach (SoundsPlayer soundsPlayer in SoundsPlayers)
        {
            if (soundsPlayer.soundCategory == Sounds[(int)soundID].Category)
            {
                soundsPlayer.audioSource.clip = Sounds[(int)soundID].sound;

                if (Sounds[(int)soundID].loop)
                {
                    soundsPlayer.audioSource.loop = true;
                }
                else
                {
                    soundsPlayer.audioSource.loop = false;
                }
                soundsPlayer.audioSource.Play();
            }
        }
    }

    public void PlaySoundString(string soundId){
        SoundID soundID = (SoundID)Enum.Parse(typeof(SoundID), soundId);
        playSound(soundID);
    }

    public void PlaySound(SoundID soundID,float volume,float pitch){
        //TODO: Play sound with volume and pitch
    }

    public void stopSound(SoundID soundID)
    {
        foreach (SoundsPlayer soundsPlayer in SoundsPlayers)
        {
            if (soundsPlayer.soundCategory == Sounds[(int)soundID].Category)
            {
                soundsPlayer.audioSource.Stop();
                //remove clip and loop
                soundsPlayer.audioSource.clip = null;
                soundsPlayer.audioSource.loop = false;
            }
        }
    }

    public void setupPlayerPrefs()
    {

        PlayerPrefs.SetInt("Time", 60);
        PlayerPrefs.SetFloat("CLOCK.Volume", 1.0f);
        PlayerPrefs.SetFloat("GAME.Volume", 1.0f);
        PlayerPrefs.SetFloat("UI.Volume", 1.0f);
        PlayerPrefs.SetString("InteractedGame", "None");
    }

    public void BackToMenu()
    {
        //load "MainScene" scene

        Application.LoadLevel("MainScene");
        PlayerPrefs.SetInt("Time", 60);
        PlayerPrefs.SetString("InteractedGame", "None");
        ClockObject.SetActive(false);
        currentClockTime = 0;
        maxClockTime = 0;
        NORMAL_CLOCK = false;
        END_TIME_CLOCK = false;

    }

    public void GameDataExecute(GameData data){
        if(data.win){

        }else{

        }
    }
}

public class GameData {
    public int RestTime = 0;
    public int MaxTime = 0;
    public string sceneName = "";
    public string gameName = "";
    public bool win = false;

    public int score = 0;

    public GameData(int restTime, int maxTime, string sceneName, string gameName, bool win, int score){
        this.RestTime = restTime;
        this.MaxTime = maxTime;
        this.sceneName = sceneName;
        this.gameName = gameName;
        this.win = win;
        this.score = score;
    }
}