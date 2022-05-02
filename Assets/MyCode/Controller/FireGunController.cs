using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunController : MonoBehaviour
{
    
    public GameObject Bullet;
    public GameObject ShootAim;
    private int _munition;
    private int _bulletType;
    private UIController _uicontroller;

    public void SetMunition(int munition) {
        _munition = munition;
    }

    public void SetBulletType(int bulletType) {

        _bulletType = bulletType;
    }

    private void Start() {
        _uicontroller = GameObject.FindGameObjectWithTag("UI").gameObject.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(Utils.BUTTON_FIRE) && (_munition > -1)) {

           GameObject bullet = Instantiate(Bullet,ShootAim.transform.position,ShootAim.transform.rotation);
           BulletController bulletController = bullet.gameObject.GetComponent<BulletController>();
            bulletController.DefineBulletById(_bulletType);
            _uicontroller.SetBulletText(_munition);
           _munition--;

        }


    }
}
