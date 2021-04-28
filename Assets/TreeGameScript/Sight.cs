using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    [SerializeField] float sightRange = 1;                                                         //視線範圍(半徑)
    public float SightRange { get => sightRange; }
    public LayerMask treeMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] allTree = Physics2D.OverlapCircleAll(transform.position, sightRange, treeMask);
        foreach (Collider2D tree in allTree)
        {
            tree.GetComponent<TreeControll>().UpdateSprite();
        }
    }
}
