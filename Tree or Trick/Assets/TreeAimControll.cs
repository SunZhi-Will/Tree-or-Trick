using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAimControll : MonoBehaviour
{
    public float speed = 2.5f;
    public GameObject attackPoint;
    public float attackRange;
    public LayerMask childMask;
    public int bullteNum = 2;
    bool isCoolDown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < (Camera.main.orthographicSize - (transform.localScale.y)))
                transform.Translate(transform.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > ((-Camera.main.orthographicSize) + (transform.localScale.y)))
                transform.Translate(-transform.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < ((Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x)))
                transform.Translate(transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > ((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x)))
                transform.Translate(-transform.right * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (bullteNum > 0)
            {
                if (!isCoolDown)
                {
                Attack();
                bullteNum -= 1;
                }
            };
        }

    }
    void Attack()
    {
        EffectsMusic.AudioAttack();
        isCoolDown = true;
        Collider2D[] allChild = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, childMask);
        StartCoroutine(AttackAni());
        if (allChild.Length > 0)
        {
            if (allChild[allChild.Length - 1].gameObject.tag == "Child")
            {
                GameManage.childIsDead = true;
                allChild[allChild.Length - 1].gameObject.GetComponent<ChildControll>().Hunt();
            }
            if (allChild[allChild.Length - 1].gameObject.tag == "AIChild")
            {
                allChild[allChild.Length - 1].gameObject.GetComponent<ChildAI>().Hunt();
            }

        }
    }
    IEnumerator AttackAni()
    {
        transform.localScale = new Vector2(4,4);
        float count = 36;
        while(count >= 20)
        {
            count -= 1;
            yield return new WaitForEndOfFrame();
            transform.localScale = new Vector2(count / 10f, count / 10f);
        }
        isCoolDown = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
