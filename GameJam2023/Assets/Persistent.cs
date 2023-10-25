using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //verify if exist more than one instance of this object
        if (FindObjectsOfType<Persistent>().Length > 1)
        {
            //destroy this object
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
