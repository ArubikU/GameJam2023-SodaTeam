using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using GameObject = UnityEngine.GameObject;
using TMPro;

public class GameSelector : MonoBehaviour
{
    public Button button;
    public Button OptionsButton;
    public Image image;
    
    public Game game;

    public PlayerUISearcher playerUI;
    public GameObject playButton;

    public TMP_Text text = null;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null){
            if(PlayerPrefs.GetInt(game.sceneName+".Time") == 0 || PlayerPrefs.GetInt(game.sceneName+".Time") == null){
                PlayerPrefs.SetInt(game.sceneName+".Time", game.time);
            }
            text.text = ""+PlayerPrefs.GetInt(game.sceneName+".Time")+"S";
        }
    }

    public void Setup(){
        OptionsButton = this.transform.GetChild(2).GetComponent<Button>();
        button = this.transform.GetChild(1).GetComponent<Button>();

        text = this.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>();

        //get first children
        image = this.transform.GetChild(0).GetComponent<Image>();
        if(!game.animatedIcon){
        image.sprite = game.icon;
        }else{
            //set the first icon of the animated icons
            image.sprite = game.animatedIcons[0];
        }

        playerUI = new PlayerUISearcher();
        playButton = game.PlayButton;
        //set button onClick action
        button.onClick.AddListener(() => {
            playerUI.getPlayerUI().GetComponent<PlayerUI>().setInteractedGame(game.sceneName);
            playerUI.getPlayerUI().GetComponent<PlayerUI>().StartClock(PlayerPrefs.GetInt(game.sceneName+".Time"));

            playerUI.getPlayerUI().GetComponent<PlayerUI>().playSound(SoundID.MENU_BUTTON);
            if(game.sceneName.Contains(",")){
                string[] scenes = game.sceneName.Split(",");
                int random = Random.Range(0, scenes.Length);
                Application.LoadLevel(scenes[random]);
            }else{

            Application.LoadLevel(game.sceneName);
            }
        });
        OptionsButton.onClick.AddListener(() => {
            playerUI.getPlayerUI().GetComponent<PlayerUI>().playSound(SoundID.MENU_BUTTON);
            playerUI.getPlayerUI().GetComponent<PlayerUI>().setInteractedGame(game.sceneName);
            playButton.GetComponent<PlayButton>().TimePanelClick();
        });
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        game.CurrentTick++;
        if (game.CurrentTick >= game.FrameRate && game.animatedIcon)
        {
            game.CurrentTick = 0;
            game.CurrentFrame++;
            if (game.CurrentFrame >= game.animatedIcons.Count)
            {
                game.CurrentFrame = 0;
            }
            //set the sprite to the first frame
            image.sprite = game.animatedIcons[game.CurrentFrame];
        }
    }
}
