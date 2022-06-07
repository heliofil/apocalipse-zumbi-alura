using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    
    private Slider _sliderPlayer;
    private Slider _sliderZumbi;
    private Slider _sliderBoss;
    private TextMeshProUGUI _zumbiText;
    private TextMeshProUGUI _bulletText;
    private TextMeshProUGUI _scoreText;
    private static UIController uIInstance;
    private Image _zumbiImg;
    private int _scorePoints;

    public static UIController UIInstance {
        get {
        if(!uIInstance) {
                uIInstance = GameObject.FindWithTag("UI").GetComponent<UIController>();
            }

        return uIInstance; 
    }
}


    public void SetScore(int points) {
        _scorePoints += points;
        _scoreText.text = _scorePoints.ToString();
    }

    public void SetLifeBar(int lifeBar) {
        _sliderPlayer.value = lifeBar;
    }


    public void SetBulletColor(Color color) {
        _bulletText.color = color;
    }

    public void SetBulletText(int munition) {
        _bulletText.text = munition.ToString();
    }

    private string GetTimeText(string baseText,float gameOverTime) {
        int timeMin = (int)(gameOverTime / 60);
        int timeSec = (int)(gameOverTime % 60);
        return string.Format(baseText,timeMin,timeSec);
    }

    private string GetSurviveTimeBestText(float gameOverTime) {
        float surviveTime = PlayerPrefs.GetFloat(Utils.SURVIVE_TIME_TAG);
        if(surviveTime < gameOverTime) {
            surviveTime = gameOverTime;
            PlayerPrefs.SetFloat(Utils.SURVIVE_TIME_TAG,surviveTime);
        }
        return GetTimeText(Utils.SURVIVE_TIME_BEST_TEXT,surviveTime);
    }

    private string GetScoreTimeBestText(int score) {
        int scoreBest = PlayerPrefs.GetInt(Utils.SCORE_TAG);
        if(scoreBest < score) {
            scoreBest = score;
            PlayerPrefs.SetInt(Utils.SCORE_TAG,scoreBest);
        }
        return string.Format(Utils.SCORE_BEST_TEXT,scoreBest);
    }


    public void GameOver() {
        HideZumbi();
        float gameOverTime = Time.timeSinceLevelLoad;
        
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).GetChild(1)
            .GetComponent<TextMeshProUGUI>().text = string.Format(Utils.SCORE_TEXT,_scorePoints);
        transform.GetChild(0).GetChild(0).GetChild(2)
            .GetComponent<TextMeshProUGUI>().text = GetTimeText(Utils.SURVIVE_TIME_TEXT,gameOverTime);
        transform.GetChild(0).GetChild(0).GetChild(4)
            .GetComponent<TextMeshProUGUI>().text = GetScoreTimeBestText(_scorePoints);
        transform.GetChild(0).GetChild(0).GetChild(5)
            .GetComponent<TextMeshProUGUI>().text = GetSurviveTimeBestText(gameOverTime);
       

        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(Utils.SCENE_PARKING);
        Time.timeScale = 1;
    }

    public void SetMaxLifeBar(int life) {
        _sliderPlayer.maxValue = life;
    }

    public void InitHitZumbi(ZumbiDomain zumbi) {
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        _sliderZumbi.maxValue = zumbi.InitialLife;
        _sliderZumbi.value = zumbi.InitialLife;
        _zumbiText.text = zumbi.Name;
        _zumbiImg.sprite = Utils.GetZumbiSpriteById(zumbi.Id);
    }

    public void InitBoss(BossDomain boss) {
        transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        _sliderBoss.maxValue = boss.InitialLife;
        _sliderBoss.value = boss.InitialLife;
    }

    public void SetBossBar(int lifeBar) {
        _sliderBoss.value = lifeBar;

    }

    public void SetZumbiBar(int lifeBar) {
        _sliderZumbi.value = lifeBar;
    }

    public void HideZumbi() {
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
    }

    public void HideBoss() {
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
    }


    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        _sliderPlayer = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Slider>();
        _bulletText = transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        _scoreText = transform.GetChild(1).GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>();

        _sliderZumbi = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Slider>();
        _zumbiText = transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        _zumbiImg = transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();

        _sliderBoss = transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Slider>();


        _bulletText.text = 0.ToString();
        _bulletText.color = Color.white;

        _scoreText.text = "000";

        _scorePoints = 0;

    }

}
