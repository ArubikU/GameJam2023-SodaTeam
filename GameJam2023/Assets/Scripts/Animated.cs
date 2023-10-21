using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Animated : MonoBehaviour
{
    
[SerializeField]
List<Sprite> AnimatedSprites = new List<Sprite>();


[SerializeField]
int FrameRate = 1;

int CurrentFrame = 0;

bool IsPlaying = false;
int CurrentTick = 0;
    // Start is called before the first frame update
    void Start()
    {
        //get the image component of the game object
        Image spriteRenderer = GetComponent<Image>();
        //set the sprite to the first frame
        spriteRenderer.sprite = AnimatedSprites[CurrentFrame];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTick++;
        if (CurrentTick >= FrameRate)
        {
            CurrentTick = 0;
            CurrentFrame++;
            if (CurrentFrame >= AnimatedSprites.Count)
            {
                CurrentFrame = 0;
            }
            //get the image component of the game object
            Image spriteRenderer = GetComponent<Image>();
            //set the sprite to the first frame
            spriteRenderer.sprite = AnimatedSprites[CurrentFrame];
        }
    }

    public void Pause(){
        IsPlaying=false;
    }
}
