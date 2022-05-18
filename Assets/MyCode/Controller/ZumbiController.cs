using UnityEngine;

public class ZumbiController : MonoBehaviour{
   
    

    private ZumbiDomain zumbi;
    public AudioClip AttackAudio;
    private BulletDomain bullet;
    private BasicAnimator basicAnimator;


    private void Start() {
        basicAnimator = GetComponent<BasicAnimator>();
    }

    public static void CreateInstance(int id,Vector3 position,Quaternion rotation) {
        Instantiate(Resources.Load<GameObject>(Utils.ZUMBI_PATH),position,rotation)
           .GetComponent<ZumbiController>()
           .DefineZumbiById(id);
    }


    public void SetBullet(BulletDomain bulletDomain) {
        bullet = bulletDomain;
    }

    public void DefineZumbiById(int id) {
        zumbi = new ZumbiDomain(GetComponent<Rigidbody>(),id);
        transform.GetChild(zumbi.Id).gameObject.SetActive(true);
    }

    void FixedUpdate() {
        
        if(TakeHit()) {
            basicAnimator.OnTakeHit(true);
            return;
        }
        basicAnimator.OnTakeHit(false);
        zumbi.Rotation(OffsetPlayer());

        if(DistancePlayer() < Utils.IMPACT_DISTANCE) {
            basicAnimator.OnAttack(true);
            return;
        }
        basicAnimator.OnAttack(false);
        zumbi.Move(OffsetPlayer()); 

    }

    Vector3 OffsetPlayer() {
        return (PlayerController.PlayerInstance.gameObject.transform.position - transform.position).normalized;
    }

    float DistancePlayer() {
        return Vector3.Distance(transform.position, PlayerController.PlayerInstance.gameObject.transform.position);  
    }

    void Attack() {

        PlayerController.PlayerInstance.TakeHit(zumbi.Strength);
    }

    bool TakeHit() {
        if(bullet == null) {
            return false;
        }
        int hit = bullet.GetNextHit();
        if(hit == 0) {
            return false ;
        }
        if(zumbi.ReduceLife(hit)) {
            AudioSourceController.AudioSourceInstance.PlayOneShot(AttackAudio);
            Destroy(gameObject);
        }
        return true;
         
    }

}
