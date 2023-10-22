using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class GameSelector : MonoBehaviour
{
    public Button button;
    public Image image;
    public Game game;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(){
        button = this.transform.GetChild(1).GetComponent<Button>();
        //get first children
        image = this.transform.GetChild(0).GetComponent<Image>();
        image.sprite = game.icon;
    }
}
