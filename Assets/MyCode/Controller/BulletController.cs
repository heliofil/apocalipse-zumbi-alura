using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    private Rigidbody rigidbd;
    private BulletDomain bullet;




    public static void CreateInstance(int id,Vector3 position, Quaternion rotation) {
        BulletController bulletController = Instantiate(Resources.Load<GameObject>(Utils.BULLET_PATH),position,rotation).GetComponent<BulletController>();
        bulletController.transform.GetChild(id).gameObject.SetActive(true);
        bulletController.bullet = new BulletDomain(id);
    }


   
    void Start()
    {
        rigidbd = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        Moviment();
        BulletLife();
    }

   
   
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<ZumbiController>(out ZumbiController zumbi)) {
            zumbi.SetBullet(bullet);
        }
        Destroy(gameObject);
    }

   private void Moviment() {
        rigidbd.MovePosition(
           rigidbd.position + bullet.Speed * Time.deltaTime * transform.forward);
        ;
    }

    private void BulletLife() {
        if(bullet.ReduceLife(1)) {
            Destroy(gameObject);
        }
    }

}
