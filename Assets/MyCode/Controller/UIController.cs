using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    private Slider _slider;
    private bool _gameOver;


    public void SetLifeBar(int lifeBar) {
        _slider.value = lifeBar;
    }

    public void GameOver() {

        _gameOver = true;
        transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(Utils.SCENE_PARKING);
        Time.timeScale = 1;
    }

    public void MaxLife(int life) {
        _slider.maxValue = life;
    }

    void Start() {
        _slider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        _gameOver = false;
    }


    void Update() {
        if((_gameOver) && (Input.GetButtonDown(Utils.BUTTON_FIRE))) {
            Restart();
        }
    }




}
