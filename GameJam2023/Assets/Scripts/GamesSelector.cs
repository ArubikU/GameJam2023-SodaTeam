using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sprite = UnityEngine.Sprite;
using Scene = UnityEngine.SceneManagement.Scene;
using Prefab = UnityEngine.GameObject;
[System.Serializable]
public class Game {
    [SerializeField]
    public Scene scene;
    public string sceneName;
    public string name;
    public string description;
    public Sprite icon;
    
    public Prefab PlayerUI;
    
}

public class GamesSelector : MonoBehaviour
{

    [SerializeField]
    public Game[] games;
    [SerializeField]
    public Prefab prefab;

    // Start is called before the first frame update
    void Start()
    {
        //instantiate the prefab with 125 distance from other in X axis and get the GameSelector component
        for (int i = 0; i < games.Length; i++)
        {
            Prefab gameSelector = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
            GameSelector gameSelectorComponent = gameSelector.GetComponent<GameSelector>();
            //set the gameSelectorComponent values
            gameSelectorComponent.game = games[i];
            gameSelectorComponent.Setup();

            //set gameSelector as child of this game object
            gameSelector.transform.SetParent(this.transform);
            //move the X and Y to 0 and 0
            //changue the scale to 1.1 1.1 1
            gameSelector.transform.localPosition = new Vector3(0,0,0);
            gameSelector.transform.localScale = new Vector3(1.1f,1.1f,1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
