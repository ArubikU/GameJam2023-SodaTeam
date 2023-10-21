using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] 
    List<GameObject> ListGrillos = new List<GameObject>();
    [SerializeField] float timer;
    [SerializeField] TMP_Text text_Timer;
    public float time_speed;
    [SerializeField] int random;
    float time_2;
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
            forlist();
            //change scene
        }
    }

    void Selected()
    {
        time_2 += Time.deltaTime;

        if (time_speed < time_2)
        {
            forlist();

            random = UnityEngine.Random.Range(0, ListGrillos.Count);
            ListGrillos[random].GetComponent<Image>().color = Color.green;

            time_2 = 0;
        }
    }
    void forlist()
    {
        for (int i = 0; i < ListGrillos.Count; i++)
        {
            ListGrillos[i].GetComponent<Image>().color = Color.white;
        }
    }
}
