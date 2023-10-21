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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] 
    GameObject TimePanel;

    public void MainClick()
    {

        foreach (Button button in MainGuiButtons)
        {
            //disable buttons
            button.interactable = false;
             Debug.Log("Button Disabled: " + button.name);
        }

        //enable time panel
        TimePanel.SetActive(true);

    }
}
