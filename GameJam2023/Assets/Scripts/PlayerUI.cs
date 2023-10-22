
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

[System.Serializable]
public class SerializableColor{
	
    [SerializeField]
	public	float[]			colorStore = new float[4]{1F,1F,1F,1F};
    [SerializeField]
	public	Color			Color{
		get{ return new Color( colorStore[0], colorStore[1], colorStore[2], colorStore[3] );}
		set{ colorStore = new float[4]{ value.r, value.g, value.b, value.a  };				}
	}

	//makes this class usable as Color, Color normalColor = mySerializableColor;
	public static implicit operator Color		( SerializableColor instance ){
		return instance.Color;
	}

	//makes this class assignable by Color, SerializableColor myColor = Color.white;
	public static implicit operator SerializableColor		( Color color ){
		return new SerializableColor{ Color = color};
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
    private int currentClockTime;
    private int maxClockTime = 0;

    private int currentTick;


    [SerializeField]    SerializableColor[] ClockColors ;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetInt("Time", 60);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        currentTick++;

        if(currentTick % 50 == 0 && maxClockTime > 0 && currentClockTime > 0){
            currentClockTime--;
            updateClock(currentClockTime);
        }
    }

    public int getTime(){
        return currentClockTime;
    }

    public void StartClock(int time){
        //enable clock
        ClockObject.SetActive(true);
        currentClockTime = time;
        maxClockTime = time;
    }

    public SerializableColor getColor(){
        //get amount of colors
        int colorAmount = ClockColors.Length;
        //get current color index in refeer of percent from maxClockTime and currentClockTime
        int colorIndex = (int) MathF.Floor( (float) currentClockTime / (float) maxClockTime * (float) colorAmount );
        //return color
        //inverse colorIndex
        colorIndex = colorAmount - colorIndex - 1;
        return ClockColors[colorIndex];
    }

    public void updateClock(int time){
        currentClockTime = time;
        ClockText.text = time.ToString() + "s";
        //make clock text blink if time is less than 25%
        if(time < maxClockTime / 4){
            ClockText.color = new Color(0.0f, 0.0f, 0.0f, Mathf.Sin(Time.time * 10.0f));
        }
        else{
            ClockText.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }

        ClockFill.color = getColor().Color;
        //set ClockFill FillAmount to currentClockTime / maxClockTime
        ClockFill.fillAmount = (float) currentClockTime / (float) maxClockTime;
        //inverse fillAmount
        ClockFill.fillAmount = 1.0f - ClockFill.fillAmount;
    }

    public void setInteractedGame(string gameName){
        PlayerPrefs.SetString("InteractedGame", gameName);
    }

    public void setPlayerTime(int time){
        PlayerPrefs.SetInt(PlayerPrefs.SetString("InteractedGame", gameName)+".Time", time);
    }
}