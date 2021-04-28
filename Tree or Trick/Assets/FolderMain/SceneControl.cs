using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void SwitchScene(){
        StartCoroutine(SwitchSceneSeconds());
    }
    public IEnumerator SwitchSceneSeconds(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}
