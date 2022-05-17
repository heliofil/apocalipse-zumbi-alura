using UnityEngine;

public class ZumbiController : MonoBehaviour{
   
    

    private ZumbiDomain zumbi;
    private Animator animator;

    public AudioClip AttackAudio;
   
    private BulletDomain bullet;

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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        
        if(TakeHit()) {
            animator.SetBool(Utils.ON_TAKE_HIT,true);
            return;
        }
        animator.SetBool(Utils.ON_TAKE_HIT,false);
        zumbi.Rotation(Offset());

        if(Distance() < Utils.IMPACT_DISTANCE) {
            animator.SetBool(Utils.ON_ATTACK,true);
            return;
        }
        animator.SetBool(Utils.ON_ATTACK,false);
        zumbi.Move(Offset()); 

    }

    Vector3 Offset() {
        return (PlayerController.PlayerInstance.gameObject.transform.position - transform.position).normalized;
    }

    float Distance() {
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
