using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Start() {
        #if UNITY_STANDALONE 
            transform.GetChild(2).gameObject.SetActive(true);
        #endif
    }

    public void NewGame() {
        StartCoroutine(DelayNewGame());
    }
    public void ExitGame() {
        StartCoroutine(DelayExitGame());
    }

    IEnumerator DelayNewGame() {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(Utils.SCENE_PARKING);
    }

    IEnumerator DelayExitGame() {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }


}
