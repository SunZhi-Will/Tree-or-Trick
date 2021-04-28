using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void SwitchScene(){
        StartCoroutine(SwitchSceneSeconds(1));
    }
    public void MapScene()
    {
        StartCoroutine(SwitchSceneSeconds(2));
    }
    public IEnumerator SwitchSceneSeconds(int index){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);
    }
}
