using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Item;
    public GameObject Fire;
    public GameObject Killfloor;

    public Transform Northpoint;
    public Transform Eastpoint;
    public Transform Southpoint;
    public Transform Westpoint;

    public float itemSpawnDelay = 2;
    public float fireSpawnTime = 1;
    float timeElapsed = 0;
    public float fireTime = 0;
    //bool timer = false;

    [Range (1, 10)] public int itemcount = 5;
    [Range(1, 10)] public int firecount = 8;

    public int score;
    public TextMeshPro scoreText;

    public GameObject[] Collectibles;

    private void Start(){
        //SpawnItem();
        //InvokeRepeating("SpawnItem", 2, 2);
    }

    private void Update(){
        //Timer
        if (timeElapsed < itemSpawnDelay) {
            timeElapsed += Time.deltaTime;
        } else {
            SpawnItem();
            timeElapsed = 0;
        }

        if (fireTime < fireSpawnTime) { 
            fireTime += Time.deltaTime;
        } else
        {
            SpawnFire();
            fireTime = 0;
        }

        scoreText.text = "Score: " + score.ToString();
    }
    public void SpawnItem(){
        int randomIndex = Random.Range (0, Collectibles.Length);
        Instantiate(Collectibles[randomIndex], pos(), Quaternion.identity);
    }

    public void SpawnFire(){
        Instantiate(Fire, pos(), Quaternion.identity);
    }

    private Vector2 pos(){
        float xValue = Random.Range(Westpoint.position.x,Eastpoint.position.x);
        Vector2 temp = new Vector2(xValue, Northpoint.position.y);
        return temp;
    }

    public void IncreaseScore()
    {
        score += 10;
    }

    public void AdjustScore(int value)
    {
        score += value;
    }
}
