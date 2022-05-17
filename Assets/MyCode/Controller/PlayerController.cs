using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Vector3 direction;
    
    private BasicDomain player;
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
        player.EnableSlow();
    }

    public void NoGun() {
        player.DisableSlow();
    }

    // Start is called before the first frame update
    void Awake()
    {
        
        player = new BasicDomain(GetComponent<Rigidbody>());
        UIController.UIInstance.SetMaxLifeBar(player.Life);
        UIController.UIInstance.SetLifeBar(player.Life);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        direction.Set(Input.GetAxis(Utils.HORIZONTAL), 0,Input.GetAxis(Utils.VERTICAL));

        if(direction != Vector3.zero)
        {
            //animator.SetBool(Utils.ON_MOVE,true);
            if(player.Walk) {
               // animator.SetBool(Utils.ON_RUN,false);
            }
            
            
        }
    }

    void FixedUpdate() {

        if(direction != Vector3.zero) {
            player.Move(direction);
            player.Rotation(direction);
        }


        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(raio,out RaycastHit hit,100,BaseFloor)) {
            Vector3 aim = hit.point - transform.position;
            aim.y = 0;
            player.Rotation(aim);
        }

    }

    




}
