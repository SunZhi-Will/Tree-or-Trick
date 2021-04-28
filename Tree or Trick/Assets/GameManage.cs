using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject Child, childAI, treeAim, Tree;
    public int treeNum, childAiNum;
    Vector2 nextPosition;
    public static bool childIsDead = false;
    public static bool treeIsLose = false;


    List<Vector2> allPos = new List<Vector2>();
    void Start()
    {
        for (int i = 0; i < treeNum; i++)
        {
            /* float zeroPointX = ((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2));
             float unitPointX = ((Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2)) / treeNum;
             float zeroPointY = (-Camera.main.orthographicSize + (transform.localScale.y / 2));
             float unitPointY = (Camera.main.orthographicSize - (transform.localScale.y / 2)) / treeNum;
             nextPosition = new Vector2(Random.Range(zeroPointX + (unitPointX * i), zeroPointX + ( unitPointX * (i + 1)))
 , Random.Range(zeroPointY + unitPointY * i, zeroPointY +  unitPointY * (i + 1)));*/
            nextPosition = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
    , Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
            Instantiate(Tree, LocationProximityJudgment(), transform.rotation);
        }
        for (int i = 0; i < childAiNum; i++)
        {
            nextPosition = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
, Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
            Instantiate(childAI, nextPosition, transform.rotation);
        }
        nextPosition = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
, Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
        Instantiate(Child, nextPosition, transform.rotation);
        nextPosition = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
, Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
        Instantiate(treeAim, nextPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (childIsDead)
        {
            childIsDead = false;
            GameObject.Find("WIN").GetComponent<WinConditions>().TreeOrChildWin(true);
            //Reload();
        }
    }
    public void Reload()
    {
        childIsDead = false;
        SceneManager.LoadScene("TreeGame");
    }

    Vector2 LocationProximityJudgment(){
        bool LocationTooClose = true;
        int i= 0;
        while(LocationTooClose && i<10){
            i++;
            LocationTooClose = false;
            nextPosition = new Vector2(Random.Range((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2), (Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2))
    , Random.Range((-Camera.main.orthographicSize) + (transform.localScale.y / 2), Camera.main.orthographicSize - (transform.localScale.y / 2)));
            if(allPos != null){
                foreach (var item in allPos)
                {
                    if(item.x - nextPosition.x + item.y - nextPosition.y < 1f && item.x - nextPosition.x + item.y - nextPosition.y > -1f){
                        LocationTooClose = true;
                        
                    }
                    if(i == 9){
                        Debug.Log(item.x - nextPosition.x + item.y - nextPosition.y);
                    }
                }
            }
        }
        
        allPos.Add(nextPosition);
        return nextPosition;
        
    }
}
