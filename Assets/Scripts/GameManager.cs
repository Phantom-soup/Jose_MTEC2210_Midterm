using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Item;
    public Transform Northpoint;
    public Transform Eastpoint;
    public Transform Southpoint;
    public Transform Westpoint;

    public float itemSpawnDelay = 2;
    float timeElapsed = 0;
    //bool timer = false;

    [Range (1,10)]public int itemcount = 5;
    int currentItemCount = 0;

    private void Start(){
        //SpawnItem();
        //InvokeRepeating("SpawnItem", 2, 2);
    }

    private void Update(){
        //Timer
        if (timeElapsed < itemSpawnDelay) {
            timeElapsed += Time.deltaTime;
        }
        else{
            SpawnItem();
            timeElapsed = 0;
        }
    }
    public void SpawnItem(){
        if (currentItemCount < itemcount){
            Instantiate(Item, pos(), Quaternion.identity);
            currentItemCount++;
        }
            //Debug.Log(clone.transform.position);
            Debug.Log(currentItemCount.ToString());
    }

    private Vector2 pos(){
        float xValue = Random.Range(Westpoint.position.x,Eastpoint.position.x);
        float yValue = Random.Range(Northpoint.position.y,Southpoint.position.y);
        Vector2 temp = new Vector2(xValue, yValue);
        return Camera.main.ScreenToWorldPoint(temp);
    }

}
