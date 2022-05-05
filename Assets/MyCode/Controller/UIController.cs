using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    private Slider _slider;
    private TextMeshProUGUI _bulletText;
    private bool _gameOver;


    public void SetLifeBar(int lifeBar) {
        _slider.value = lifeBar;
    }

    public void SetBulletColor(Color color) {
        _bulletText.color = color;
    }

    public void SetBulletText(int munition) {
        _bulletText.text = munition.ToString();
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

    public void SetMaxLifeBar(int life) {
        _slider.maxValue = life;
    }

    void Start() {
        _slider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        _bulletText = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _gameOver = false;
        _bulletText.text = 0.ToString();
        _bulletText.color = Color.white;
    }


    void Update() {
        if((_gameOver) && (Input.GetButtonDown(Utils.BUTTON_FIRE))) {
            Restart();
        }
    }




}
