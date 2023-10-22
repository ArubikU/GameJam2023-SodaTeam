using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class identyWord : MonoBehaviour
{
    [SerializeField] string word;
    [SerializeField] List<TheVariant> words = new List<TheVariant>();
    void Start()
    {
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