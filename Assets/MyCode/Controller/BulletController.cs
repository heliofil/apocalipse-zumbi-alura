using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    
    private BulletDomain bullet;


    public static void CreateInstance(int id,Vector3 position, Quaternion rotation) {
        BulletController bulletController = Instantiate(Resources.Load<GameObject>(Utils.BULLET_PATH),position,rotation).GetComponent<BulletController>();
        bulletController.transform.GetChild(id).gameObject.SetActive(true);
        bulletController.bullet = new BulletDomain(bulletController.GetComponent<Rigidbody>(),id);
    }



    void FixedUpdate()
    {
        bullet.Move(transform.forward);
        BulletLife();
    }

   
   
    private void OnTriggerEnter(Collider other) {
        switch(other.tag) {
            case Utils.ZUMBI_TAG:
               other.GetComponent<ZumbiController>().SetBullet(bullet);
            break;
            case Utils.BOSS_TAG:
                other.GetComponent<BossController>().TakeHit(bullet.AllHits);
            break;
        }
        Destroy(gameObject);

    }


    private void BulletLife() {
        if(bullet.ReduceLife(1)) {
            Destroy(gameObject);
        }
    }

}
