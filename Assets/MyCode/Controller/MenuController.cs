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
        SceneManager.LoadScene(Utils.SCENE_PARKING);
    }
    public void ExitGame() {
        Application.Quit();
    }

}
