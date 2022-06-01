using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour, ILivingController {

    public AudioClip AttackAudio;
    private PlayerController player;
    private BossDomain boss;
    private BasicAnimator animator;
    private UIController uiInstance;
    

    private static BossController bossInstance;
    public static BossController BossInstance {
        get {

            if(!bossInstance) {
                bossInstance = GameObject.FindWithTag(Utils.BOSS_TAG).GetComponent<BossController>();
            }

            return bossInstance;

        }
    }

    public void Restore() {
        boss.RestoreLife();
    }

    public void TakeHit(int hit) {
        boss.ReduceLife(hit);
        
    }

    IEnumerator PrepareToDie() {
        animator.OnDie();
        AudioSourceController.AudioSourceInstance.PlayOneShot(AttackAudio);
        uiInstance.SetScore(boss.Points);
        boss.Rigidbody.isKinematic = false;
        boss.Agent.enabled = false;
        yield return new WaitForSeconds(Utils.IMPACT_DISTANCE);
        ToDie();
    }

    public void ToDie() {
        boss.DropOut();
        GetComponent<Collider>().enabled = false;
        enabled = false;
        Destroy(gameObject,Utils.IMPACT_DISTANCE);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.PlayerInstance;
        uiInstance = UIController.UIInstance;
        boss = new BossDomain(GetComponent<Rigidbody>(),GetComponent<NavMeshAgent>());
        animator = GetComponent<BasicAnimator>();
        
    }

    void Attack() {
        player.TakeHit(boss.Strength);
       
    }


    // Update is called once per frame
    void Update()
    {

        if(boss.Dead) {
            StartCoroutine(PrepareToDie());
            this.enabled = false;
            return;
        }

        boss.Rotation(player.transform.position);
        if(boss.IsPlayerNear()) {
            animator.OnAttack(true);
            return;
        }
        animator.OnAttack(false);
        boss.Move(player.transform.position);
        if(boss.Walk) {
            animator.OnMove();
            return; 
        }
        animator.OnRun();
        
    }



}
