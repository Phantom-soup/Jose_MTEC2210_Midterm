using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Color itemColor;

    // Start is called before the first frame update
    void Start()
    {
        itemColor = GetComponent<SpriteRenderer>().color; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
