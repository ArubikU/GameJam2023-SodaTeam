using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class identyWord : MonoBehaviour
{
    [SerializeField] public string word;
    private string originalword;
    public List<TheVariant> words = new List<TheVariant>();


    [SerializeField]
    PlayerUISearcher playerUI;

    int originalTime = 0;

    public void Start()
    {
        originalword = word;
        playerUI = new PlayerUISearcher();
        originalTime = playerUI.getPlayerUI().getTime();
        for (int i = 1; i < word.Length + 1; i++)
        {
            TheVariant variant = new ();
            if (i == 1)
            {
                variant.letra = (word[..i]);
            }
            else
            {
                variant.letra = (word[(i - 1)..i]);
            }
            variant.active = false;
            words.Add(variant);

        }
    }
    public void Delete()
    {
        if (words.Count > 0)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if(words[i].active == true)
                {
                    words.RemoveAt(i);
                }
            }
        }
        else
        {

            
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            GameData data = new GameData( playerUI.getPlayerUI().getTime(),originalTime,sceneName,"scrabble",true,100);
            playerUI.getPlayerUI().GameDataExecute(data);
            Reset();
            ChangeColor changeColor = GameObject.Find("GameManager").GetComponent<ChangeColor>();
            changeColor.Reset();
            reseted = false;
        }
    }
    
    private bool reseted = false;

    void Update()
    {
        if (reseted == false)
        {
            Reset();
            reseted = true;
        }
    }

public void Reset()
{
    words.Clear();
    word = originalword;
        for (int i = 1; i < word.Length + 1; i++)
        {
            TheVariant variant = new ();
            if (i == 1)
            {
                variant.letra = (word[..i]);
            }
            else
            {
                variant.letra = (word[(i - 1)..i]);
            }
            variant.active = false;
            words.Add(variant);

        }

}
}



[System.Serializable]
public class TheVariant
{
    [SerializeField] public string letra;
    [SerializeField] public bool active;
}
