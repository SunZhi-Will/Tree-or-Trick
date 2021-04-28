using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGameManage : MonoBehaviour
{
    public GameObject child;
    public Transform[] creatPoint;
    public int enemyCount = 3;
    int index;
    void Start()
    {
        for (int i = 0; i<enemyCount; i++)
        {
            index = Random.Range(0, creatPoint.Length);
            Instantiate(child, creatPoint[index].position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
