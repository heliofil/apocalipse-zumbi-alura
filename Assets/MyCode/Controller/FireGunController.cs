using UnityEngine;

public class FireGunController : MonoBehaviour
{
    
    public GameObject ShootAim;
    public AudioClip ShootAudio;
    private int munition;
    private int bulletType;
    
    public void SetMunition(int munition) {
        this.munition = munition;
        UIController.UIInstance.SetBulletText(this.munition);
    }

    public void MunitionZero() {
        SetMunition(0);
        PlayerController.PlayerInstance.NoGun();
        transform.GetChild(0).GetChild(bulletType).gameObject.SetActive(false);
    }

    public void DefineById(int bulletType) {
        int rad = Random.Range(6,12) * Utils.GUNPACK_SIZE - bulletType;
        SetMunition(rad);
        this.bulletType = bulletType;
        UIController.UIInstance.SetBulletColor(Utils.COLOR_DEFINITION[bulletType]);
        transform.GetChild(0).GetChild(bulletType).gameObject.SetActive(true);   
        PlayerController.PlayerInstance.HasGun();
        
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
        transform.rotation = new Quaternion(transform.rotation.x + Random.Range(-0.02f,0.02f),transform.rotation.y,transform.rotation.z,transform.rotation.w);
    }

}
