using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGunController : MonoBehaviour
{
    
    public GameObject Bullet;
    public GameObject ShootAim;
    public GameObject Canvas;
    public GameObject Player;
    private int _munition;
    private int _bulletType;
    private Color _color;
    private UIController _uicontroller;
    private PlayerController _playercontroller;

    public void SetMunition(int munition) {
        _munition = munition;
        _uicontroller.SetBulletText(_munition);
    }

    public void MunitionZero() {
        SetMunition(0);
        _playercontroller.NoGun();
        transform.GetChild(0).GetChild(_bulletType).gameObject.SetActive(false);
    }

    public void SetBulletType(int bulletType) {

        _bulletType = bulletType;
        _uicontroller.SetBulletColor(Utils.COLOR_DEFINITION[bulletType]);
        transform.GetChild(0).GetChild(bulletType).gameObject.SetActive(true);   
        _playercontroller.HasGun();
        
    }

    

    private void Start() {
        _uicontroller = Canvas.GetComponent<UIController>();
        _playercontroller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_munition < 1) {
            MunitionZero();
            return;
        }

        if(Input.GetButtonDown(Utils.BUTTON_FIRE)) {

           GameObject bullet = Instantiate(Bullet,ShootAim.transform.position,ShootAim.transform.rotation);
           BulletController bulletController = bullet.gameObject.GetComponent<BulletController>();
            bulletController.DefineBulletById(_bulletType);
            SetMunition(_munition);
            _munition--;
        }


    }
}
