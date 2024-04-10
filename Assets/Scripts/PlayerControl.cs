using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gm;
    public float speed = 10;
    float turboSpeed = 20;
    float currentSpeed;
    public Color turboColor;
    private Color defaultColor;
    
    public SpriteRenderer sr;
    
    public AudioClip subtank;
    public AudioClip extraLife;
    AudioSource audioSource;

    private Item lastItemCollided;

    // Start is called before the first frame update
    void Start(){
        //sr = GetComponent<SpriteRenderer>();
        defaultColor = Color.white;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        float xMove = Input.GetAxisRaw("Horizontal");
        transform.Translate(xMove * currentSpeed * Time.deltaTime, 0, 0);
        
        if (Input.GetKey(KeyCode.Space)){
            currentSpeed = turboSpeed;
            sr.color = turboColor;
        }
        else{
            currentSpeed = speed;
            sr.color = defaultColor;
        }
        
        if (xMove != 0){
            if (xMove < 0){
                sr.flipX = true;
            }
            else{
                sr.flipX = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Item"){
            lastItemCollided = collision.gameObject.GetComponent<Item>();
            Destroy(collision.gameObject);
            Debug.Log("Item Collision");

            audioSource.PlayOneShot(subtank);
            
            int tempValue = collision.gameObject.GetComponent<Item>().value;
            gm.AdjustScore(tempValue);
        }
        else if (collision.gameObject.tag == "Transporter"){
            Debug.Log("Teleport to next theme");
            lastItemCollided = collision.gameObject.GetComponent<Item>();
            Destroy(collision.gameObject);

            audioSource.PlayOneShot(extraLife);
            
            int tempValue = collision.gameObject.GetComponent<Item>().value;
            gm.AdjustScore(tempValue);
        }
        else if (collision.tag == "Fire"){
            gm.PlayDeathSound();
            Destroy(gameObject);
        }
    }
}

