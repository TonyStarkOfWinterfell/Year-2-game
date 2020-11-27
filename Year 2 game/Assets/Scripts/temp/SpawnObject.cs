using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject FoodPrefab;
    public GameObject areaBox;

    public Vector3 area;
    public Vector3 size;

    //public Quaternion min;
        
    void Start()
    {
        area = areaBox.transform.localPosition;
        SpawnFood();
    }
   
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
            SpawnFood();
    }

    public void SpawnFood()
    {
        Vector3 pos = area + new Vector3(Random.Range(-size.x / 2, size.x /2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(FoodPrefab, pos, Quaternion.identity);
    }


    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }*/
}
