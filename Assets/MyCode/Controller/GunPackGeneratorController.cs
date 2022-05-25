using UnityEngine;

public class GunPackGeneratorController : MonoBehaviour, IGeneratorController
{
    private int timeToNew;
    private LayerMask gunPackLayerMask;
    private string[] noContact = { Utils.SCENE_OBJECT_TAG,Utils.GUNPACK_TAG };

    public void SetTimeToNew(int timeToNew) {
        this.timeToNew = timeToNew;
    }

    private void Start() {
        gunPackLayerMask = LayerMask.GetMask(noContact);
        timeToNew = Utils.TIME_TO_NEW_GUN;
    }

    private void FixedUpdate() {

        timeToNew--;

        if(timeToNew > 0) {
            return;
        }

        if(GameObject.FindGameObjectsWithTag(Utils.GUNPACK_TAG).Length > Utils.ZUMBI_MAX) {
            return;
        }

        if(Vector3.Distance(PlayerController.PlayerInstance.transform.position,transform.position) < Utils.MOVE_DISTANCE) {
            return;
        }

     
        CreateInstance();
        
    }

    public Vector3 PositionGenerator() {
        return Utils.GetRandomByPosition(transform.position,Utils.MOVE_DISTANCE);
    }

    public void CreateInstance() {
        Vector3 position = PositionGenerator();
        if(Physics.OverlapSphere(position,Utils.IMPACT_DISTANCE,gunPackLayerMask).Length > 0) {
            return;
        }
        int rad = Random.Range(0,Utils.GUNPACK_SIZE);
        GunPackController.CreateInstance(rad,position);
        SetTimeToNew(Utils.GetTimeToNew(rad * Random.Range(12,20)));
    }
        
}
