using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class NewBehaviourScript : MonoBehaviour
{
    public Button button;
    public Image image;
    public Game game;


    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        //Search a "Icon" image in the children of the button
        image = button.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(){
        image.sprite = game.icon;
    }
}
