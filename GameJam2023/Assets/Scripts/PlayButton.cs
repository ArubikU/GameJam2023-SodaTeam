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


    //Action to main Click
    public void MainClick()
    {

        foreach (Button button in MainGuiButtons)
        {
            //disable buttons
            button.interactable = false;
             Debug.Log("Button Disabled: " + button.name);
        }

        //enable time panel
        GamesPanel.SetActive(true);

    }

    public void TimePanelClick()
    {
        //enable time panel
        TimePanel.SetActive(true);
    }

    public void CloseTimePanel()
    {
        //disable time panel
        TimePanel.SetActive(false);
    }

    public void ReOpenMainGui()
    {
        foreach (Button button in MainGuiButtons)
        {
            //enable buttons
            button.interactable = true;
            Debug.Log("Button Enabled: " + button.name);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
