using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Debug = UnityEngine.Debug;
public class PlayButton : MonoBehaviour
{
[SerializeField]
List<Button> MainGuiButtons = new List<Button>();

    [SerializeField] 
    GameObject GamesPanel;
    [SerializeField] 
    GameObject TimePanel;


    [SerializeField]
    PlayerUI playerUI;
    //Action to main Click
    public void MainClick()
    {

        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        foreach (Button button in MainGuiButtons)
        {
            //disable buttons
            button.interactable = false;
             Debug.Log("Button Disabled: " + button.name);
        }

            playerUI.playSound(SoundID.MENU_BUTTON);
        //enable time panel
        GamesPanel.SetActive(true);

    }

    public void TimePanelClick()
    {
        //enable time panel
        TimePanel.SetActive(true);
            playerUI.playSound(SoundID.MENU_BUTTON);
    }

    public void CloseTimePanel()
    {
        //disable time panel
        TimePanel.SetActive(false);
            playerUI.playSound(SoundID.MENU_BUTTON);
    }

    public void ReOpenMainGui()
    {
        foreach (Button button in MainGuiButtons)
        {
            //enable buttons
            button.interactable = true;
            Debug.Log("Button Enabled: " + button.name);
            playerUI.playSound(SoundID.MENU_BUTTON);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
