using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class identyWord : MonoBehaviour
{
    [SerializeField] public string word;
    public List<TheVariant> words = new List<TheVariant>();


    [SerializeField]
    PlayerUI playerUI;

    int originalTime = 0;

    void Start()
    {
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        originalTime = playerUI.getTime();
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
            int timer = originalTime- playerUI.getTime();
            GameData data = new GameData(timer,originalTime,sceneName,"scrabble",true,100);
            playerUI.GameDataExecute(data);
        }
    }
}

[System.Serializable]
public class TheVariant
{
    [SerializeField] public string letra;
    [SerializeField] public bool active;
}
