using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControll : MonoBehaviour
{
    public int health = 3;
    bool canHit = true;
    public float coolDown = 10;
    float nowCoolDown = 0;
    public Sprite[] allTree;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!canHit)
        {
            nowCoolDown += Time.fixedDeltaTime;
            if(nowCoolDown >= coolDown && health > 0 )
            {
                canHit = true;
                nowCoolDown = 0;
            }
        }
    }
    public void HitTree()
    {
        if (canHit)
        {
            health -= 1;
            canHit = false;
            if(health == 0){
                WinConditions.g_TreeHp -= 1;
            }
            EffectsMusic.AudioHitTree();
        }
    }

    public void UpdateSprite()
    {
        if (health > 0)
        {
            GetComponent<SpriteRenderer>().sprite = allTree[health - 1];
        }
        else
        {
            
            Destroy(gameObject);
        }
    }

}
