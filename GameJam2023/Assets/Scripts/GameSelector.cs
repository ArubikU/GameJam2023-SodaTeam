using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using GameObject = UnityEngine.GameObject;

public class GameSelector : MonoBehaviour
{
    public Button button;
    public Button OptionsButton;
    public Image image;
    public Game game;

    public GameObject playerUI;
    public GameObject playButton;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(){
        OptionsButton = this.transform.GetChild(2).GetComponent<Button>();
        button = this.transform.GetChild(1).GetComponent<Button>();
        //get first children
        image = this.transform.GetChild(0).GetComponent<Image>();
        image.sprite = game.icon;

        playerUI = game.PlayerUI;
        playButton = game.PlayButton;
        //set button onClick action
        button.onClick.AddListener(() => {
            game.PlayerUI.GetComponent<PlayerUI>().setInteractedGame(game.sceneName);
            Application.LoadLevel(game.sceneName);
            playerUI.GetComponent<PlayerUI>().StartClock(PlayerPrefs.GetInt(game.sceneName+".Time"));
        });
        OptionsButton.onClick.AddListener(() => {
            game.PlayerUI.GetComponent<PlayerUI>().setInteractedGame(game.sceneName);
            playButton.GetComponent<PlayButton>().TimePanelClick();
        });
    }
}
