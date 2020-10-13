using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemManager : MonoBehaviour
{
    public GameObject[] items;

    public float radius = 30f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for(int i = 0; i < items.Length; i++)
        {
            //Create a spawn position for each item based on the radius given. Y stays the same
            Vector3 spawnPos = new Vector3(Random.Range(this.transform.position.x - radius, this.transform.position.x + radius), this.transform.position.y, Random.Range(this.transform.position.z - radius, this.transform.position.z + radius));
            
            //Spawn object in range with random rotation
            Instantiate(items[i], spawnPos, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))));
        }
    }//end of SpawnItems

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
