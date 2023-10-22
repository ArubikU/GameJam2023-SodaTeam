using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour //change name to spawn letter
{
    [SerializeField] 
    List<GameObject> Tuneles = new();
    [SerializeField]
    List<letters> letters = new();

    [SerializeField] float timer;
    [SerializeField] TMP_Text text_Timer;
    public float time_speed;
    int random;
    float time_2;
    [HideInInspector]public Vector2 postion;

    identyWord id;
    int rand;

    void Start()
    {
        Cleanlist();
        id = GetComponent<identyWord>();
    }
    void Update()
    {
        ClickA();
        Times();
        id.Delete();
    }

    private void Times()
    {
        text_Timer.text = " " + Convert.ToInt32(timer);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Selected();
        }
        else
        {
            Cleanlist();
            //change nextscene
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
            id.words[rand].active = true;
            Cleanlist();
            Debug.Log("le atinaste");
        }
    }

}

[Serializable]
public class letters
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string letra;
}
