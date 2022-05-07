using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Vector3 direction;
    private Animator animator;
    private Rigidbody rigidbd;
    private BasicDomain player;
    private bool walk;

    public LayerMask BaseFloor;
    public AudioClip TakeHitAudio;

    private static PlayerController playerInstance;
    public static PlayerController PlayerInstance {
        get {

            if(!playerInstance) {
                playerInstance = GameObject.FindWithTag(Utils.PLAYER_TAG).GetComponent < PlayerController > ();
            }
            
            return playerInstance;

        }
     }

    public void TakeHit(int hit) {

        AudioSourceController.AudioSourceInstance.PlayOneShot(TakeHitAudio);

        if(player.ReduceLife(hit)) {
            UIController.UIInstance.GameOver();
        };
        UIController.UIInstance.SetLifeBar(player.Life);

    }

    public void HasGun() {
        animator.SetBool(Utils.IS_GUN,true);
        walk = true; 
    }

    public void NoGun() {
        animator.SetBool(Utils.IS_GUN,false);
        walk = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbd = GetComponent<Rigidbody>();
        player = new BasicDomain();
        UIController.UIInstance.SetMaxLifeBar(player.Life);
        UIController.UIInstance.SetLifeBar(player.Life);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        animator.SetBool(Utils.ON_MOVE, false);
        direction.Set(Input.GetAxis(Utils.HORIZONTAL), 0,Input.GetAxis(Utils.VERTICAL));

        if(direction != Vector3.zero)
        {
            animator.SetBool(Utils.ON_MOVE, true);
            
        }
    }

    void FixedUpdate() {

        if(direction != Vector3.zero) {
            rigidbd.MovePosition(Move(direction));
            rigidbd.MoveRotation(Quaternion.LookRotation(direction));
        }


        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(raio,out RaycastHit hit,100,BaseFloor)) {
            Vector3 aim = hit.point - transform.position;
            aim.y = 0;
            rigidbd.MoveRotation(Quaternion.LookRotation(aim));
        }

    }

    Vector3 Move(Vector3 direction) {
        int speed = player.Speed;
        if(walk) {
            speed = player.Slow();
        }
        return rigidbd.position + (speed * Time.deltaTime * direction);
    }




}
