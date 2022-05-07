using UnityEngine;

public class GunPackGeneratorController : MonoBehaviour
{
    private int timeToNew;

    public void SetTimeToNew(int timeToNew) {
        this.timeToNew = timeToNew;
    }

    private void Start() {
        timeToNew = Utils.TIME_TO_NEW_GUN;
    }

    private void FixedUpdate() {

        if(timeToNew < 1) {
            int rad = Random.Range(0,Utils.GUNPACK_SIZE);
            GunPackController.CreateInstanceById(rad);
            timeToNew = Utils.GetTimeToNew(rad*Random.Range(12,20));
        } 

        timeToNew--;
    }


    

}
