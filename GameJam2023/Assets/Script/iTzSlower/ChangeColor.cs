using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ChangeColor : MonoBehaviour //change name to spawn letter
{
    [SerializeField] 
    List<GameObject> Tuneles = new();
    [SerializeField]
    List<letters> letters = new();

    int random;
    float time_2;

    [SerializeField]
    float time_speed;

    [SerializeField]
    PlayerUI playerUI;

    [HideInInspector]public Vector2 postion;

    identyWord id;
    int rand;

    int originalTime = 0;

    string sceneName = "";
    private int WordSlot = 0;
    private int wordLenght = 0;

    void Start()
    {
        GameObject.Find("Canvas/background/Time").SetActive(false);

        //find playerUI game object by tag "PlayerUI"
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        originalTime = playerUI.getTime();
        Cleanlist();
        id = GetComponent<identyWord>();
        String word = id.word;
        wordLenght = word.Length;
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        ClickA();
        Times();
        
        
        id.Delete();
    }

    private void Times()
    {   
        int timer = playerUI.getTime();
        
        if (timer > 0)
        {
            Selected();
        }
        else
        {
            Cleanlist();
            //get current scene name

            //get current letters unlocked using WordSlot and WordLenght, score from 0 to 100
            int score = ((WordSlot+1)/(wordLenght+1)) * 100;

            
            GameData data = new GameData(timer,originalTime,sceneName,"scrabble",false,score);
            playerUI.GameDataExecute(data);

            Reset();
            id.Reset();

            //change nextscene
            //lose
        }
    }

    void Selected()
    {
        time_2 += Time.deltaTime;
        if (time_speed < time_2   &&   id.words.Count > 0)
        {
            Cleanlist();

            random = UnityEngine.Random.Range(0, Tuneles.Count);

            rand = UnityEngine.Random.Range(0, id.words.Count);

            if (id.words[rand].active == true)
            {
                rand = UnityEngine.Random.Range(0, id.words.Count);
            }

            // cambiar por sprite de la palabra
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i].letra == id.words[rand].letra)
                {
                    Image image = Tuneles[random].GetComponent<Image>();
                    image.sprite = letters[i].sprite;
                }
            }
            Tuneles[random].gameObject.SetActive(true);
            postion = Tuneles[random].transform.position;
            time_2 = 0;
        }
    }
    void Cleanlist()
    {
        for (int i = 0; i < Tuneles.Count; i++)
        {
            Tuneles[i].gameObject.SetActive(false);
        }
    }


    void ClickA()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&
            id.words.Count > 0 &&
            Vector2.Distance(Input.mousePosition, postion) <= 90)
        {
            int tunel = 0;
            

            //get current "Tunel" near to mouse
            for (int i = 0; i < Tuneles.Count; i++)
            {
                if (Vector2.Distance(Input.mousePosition, Tuneles[i].transform.position) <= 90)
                {
                    tunel = i;

                }
            }
            //get what letter is in the "Tunel"
            string letter = Tuneles[tunel].GetComponent<Image>().sprite.name;
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i].sprite.name == letter)
                {
                    letter = letters[i].letra;
                }
            }
            Debug.Log("letter: " + letter);
            //compare letter with the first letter of the word and if is true delete the first letter of the word
            if (letter == id.words[0].letra)
            {
                id.words[0].active = true;
                Cleanlist();
                Debug.Log("le atinaste");
                Cleanlist();
                //get Object in path Canvas/background/Palabra
                GameObject palabra = GameObject.Find("Canvas/background/Palabra");
                //get child with the slot number
                GameObject child = palabra.transform.GetChild(WordSlot).gameObject;
                //changue color to green with a black border
                child.GetComponent<Image>().color = new Color(0, 1, 0, 1);
                child.GetComponent<Image>().material = null;
                WordSlot++;
                playerUI.playSound(SoundID.LETTER_CORRECT);
            }else{
                playerUI.playSound(SoundID.LETTER_WRONG);
            }
            
        }
    }

    public void Reset()
    {
                GameObject palabra = GameObject.Find("Canvas/background/Palabra");
                for (int i = 0; i < palabra.transform.childCount; i++)
                {
                    GameObject child = palabra.transform.GetChild(i).gameObject;
                    child.GetComponent<Image>().color = new Color(0,0,0, 1);
                    child.GetComponent<Image>().material = null;
                    WordSlot = 0;
                    wordLenght = 0;
                    originalTime = 0;
                }
    
    }

}

[Serializable]
public class letters
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string letra;
}
