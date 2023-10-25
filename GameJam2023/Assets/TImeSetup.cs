using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class TImeSetup : MonoBehaviour
{
    PlayerUISearcher playerUI;
    Button button;
    [SerializeField]
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = new PlayerUISearcher();
        button = this.GetComponent<Button>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //clear the action
        button.onClick.RemoveAllListeners();
        //add action to the button
        button.onClick.AddListener(() => {
            playerUI.getPlayerUI().PlaySoundString("MENU_BUTTON");
            playerUI.getPlayerUI().setPlayerTime(time);
        });
    }
}
