using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using Image = UnityEngine.UI.Image;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public class FinalScene : MonoBehaviour
{

    [SerializeField]
    TMP_Text score;
    [SerializeField]
    TMP_Text time;

    [SerializeField]
    Image star1;
    [SerializeField]
    Image star2;
    [SerializeField]
    Image star3;
    [SerializeField]
    public AudioSource audioSource;
    public AudioClip ButtonSound;


    PlayerUI playerUI;
    GameData data;
    // Start is called before the first frame update
    void Start()
    {
        star1.color = new Color(star1.color.r, star1.color.g, star1.color.b, 0);
        star2.color = new Color(star2.color.r, star2.color.g, star2.color.b, 0);
        star3.color = new Color(star3.color.r, star3.color.g, star3.color.b, 0);
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        data = playerUI.GameDataGet();
        score.text = "Puntos: "+data.score.ToString();
        time.text = "Tiempo Restante: "+data.RestTime.ToString();

        //score is from 0 to 100 render stars based on score and set their alpha from 0 to 1 if their percentage is reached


        if(data.score >= 0 && data.score <= 33){
            star1.color = new Color(star1.color.r, star1.color.g, star1.color.b, 1);
        }else if(data.score >= 34 && data.score <= 66){
            star1.color = new Color(star1.color.r, star1.color.g, star1.color.b, 1);
            star2.color = new Color(star2.color.r, star2.color.g, star2.color.b, 1);
        }else if(data.score >= 67 && data.score <= 100){
            star1.color = new Color(star1.color.r, star1.color.g, star1.color.b, 1);
            star2.color = new Color(star2.color.r, star2.color.g, star2.color.b, 1);
            star3.color = new Color(star3.color.r, star3.color.g, star3.color.b, 1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoMain(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainScene");
    }

    public void Retry(){
        playerUI.resetLastClock();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(data.sceneName);
    }

    
}
