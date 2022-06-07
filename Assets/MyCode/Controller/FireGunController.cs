using UnityEngine;

public class FireGunController : MonoBehaviour
{
    
    public GameObject ShootAim;
    public AudioClip ShootAudio;
    private int munition;
    private int bulletType;
    private UIController uiInstance;
    private PlayerController playerInstance;
    
    public void SetMunition(int munition) {
        this.munition = munition;
        uiInstance.SetBulletText(this.munition);
    }

    public void MunitionZero() {
        SetMunition(0);
        playerInstance.NoGun();
        transform.GetChild(0).GetChild(bulletType).gameObject.SetActive(false);
    }

    public void DefineById(int bulletType) {
        int rad = Random.Range(6,12) * Utils.GUNPACK_SIZE - bulletType;
        SetMunition(rad);
        this.bulletType = bulletType;
        uiInstance.SetBulletColor(Utils.COLOR_DEFINITION[bulletType]);
        transform.GetChild(0).GetChild(bulletType).gameObject.SetActive(true);
        playerInstance.HasGun();
        
    }

    void Start() {

        uiInstance = UIController.UIInstance;
        playerInstance = PlayerController.PlayerInstance;

    }

    // Update is called once per frame
    void Update()
    {

        if(munition < 1) {
            MunitionZero();
            return;
        }

        if(Input.GetButtonDown(Utils.BUTTON_FIRE)) {
            Shoot();
        }


    }

    void Shoot() {
        BulletController.CreateInstance(bulletType,ShootAim.transform.position,ShootAim.transform.rotation);
        SetMunition(munition);
        munition--;
        AudioSourceController.AudioSourceInstance.PlayOneShot(ShootAudio);
        float rotationX = Random.Range(-0.02f,0.02f);
        if(munition > 6) {
            rotationX += transform.rotation.x;
        }
        transform.rotation.Set(rotationX,0,0,0);
    }

}
