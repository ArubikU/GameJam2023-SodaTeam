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
    PlayerUISearcher playerUI;
    //Action to main Click
    public void MainClick()
    {

        playerUI = new PlayerUISearcher();
        foreach (Button button in MainGuiButtons)
        {
            //disable buttons
            button.interactable = false;
             Debug.Log("Button Disabled: " + button.name);
        }

            playerUI.getPlayerUI().playSound(SoundID.MENU_BUTTON);
        //enable time panel
        GamesPanel.SetActive(true);

    }

    public void TimePanelClick()
    {
        //enable time panel
        TimePanel.SetActive(true);
            playerUI.getPlayerUI().playSound(SoundID.MENU_BUTTON);
    }

    public void CloseTimePanel()
    {
        //disable time panel
        TimePanel.SetActive(false);
            playerUI.getPlayerUI().playSound(SoundID.MENU_BUTTON);
    }

    public void ReOpenMainGui()
    {
        foreach (Button button in MainGuiButtons)
        {
            //enable buttons
            button.interactable = true;
            Debug.Log("Button Enabled: " + button.name);
            playerUI.getPlayerUI().playSound(SoundID.MENU_BUTTON);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
