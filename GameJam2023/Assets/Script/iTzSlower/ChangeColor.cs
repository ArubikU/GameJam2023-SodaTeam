using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour //change name to spawn letter
{
    [SerializeField] 
    List<GameObject> Tuneles = new();
    [SerializeField]
    List<Sprite> letters = new();

    [SerializeField] float timer;
    [SerializeField] TMP_Text text_Timer;
    public float time_speed;
    int random;
    float time_2;
    [HideInInspector]public Vector2 postion;

    void Start()
    {
        Cleanlist();
    }
    void Update()
    {
        
        Times();
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
            //change scene
        }
    }

    void Selected()
    {
        time_2 += Time.deltaTime;

        if (time_speed < time_2)
        {
            Cleanlist();
            random = UnityEngine.Random.Range(0, Tuneles.Count);
            Tuneles[random].GetComponent<Image>().sprite = letters[0];
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
}
