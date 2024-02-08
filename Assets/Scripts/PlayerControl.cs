using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    float turboSpeed = 10;
    float currentSpeed;
    public Color turboColor;
    private Color defaultColor;
    public SpriteRenderer sr;

    private Item lastItemCollided;

    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        defaultColor = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = turboSpeed;
            sr.color = turboColor;
        }
        else
        {
            currentSpeed = speed;
            sr.color = defaultColor;
        }

        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        transform.Translate(xMove * currentSpeed * Time.deltaTime, yMove * currentSpeed * Time.deltaTime, 0);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("Collision");
            lastItemCollided = collision.gameObject.GetComponent<Item>();
            defaultColor = lastItemCollided.itemColor;
            sr.color = defaultColor;
            Destroy(collision.gameObject);
        }
    }
}
