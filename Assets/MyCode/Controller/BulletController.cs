using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    private Rigidbody _rigidbody;
    private int _bulletTime;
    private BulletDomain _bulletDomain;

    public void DefineBulletById(int id) {
        transform.GetChild(id).gameObject.SetActive(true);
        _bulletDomain = Utils.CreateBullet(id);
    }


    // Start is called before the first frame update
    void Start()
    {
        _bulletTime = Utils.BULLET_TIME_INIT;
        _rigidbody = GetComponent<Rigidbody>();
               
    }

    void FixedUpdate()
    {
        Moviment();
        BulletLife();
    }

   
   
    private void OnTriggerEnter(Collider other) {
            ZumbiController zumbi;
        if(other.TryGetComponent<ZumbiController>(out zumbi)) {
            zumbi.SetBullet(_bulletDomain);
        }
        Destroy(gameObject);
    }

   private void Moviment() {
        _rigidbody.MovePosition(
           _rigidbody.position + transform.forward
           * _bulletDomain.GetSpeed()
           * Time.deltaTime);
        ;
    }

    private void BulletLife() {
        _bulletTime = _bulletTime - 1;
        if(_bulletTime < 0) {
            Destroy(gameObject);
        }
    }

}
