using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Color itemColor;

    public float minimumSpeed = 1;
    public float maximumSpeed = 15;

    public int value;

    // Start is called before the first frame update
    void Start()
    {
        itemColor = GetComponent<SpriteRenderer>().color; 
    }

    // Update is called once per frame
    void Update()
    {
        float fallSpeed = Random.Range(minimumSpeed, maximumSpeed);
        transform.Translate(0, -(fallSpeed * Time.deltaTime), 0);

        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
    
}
