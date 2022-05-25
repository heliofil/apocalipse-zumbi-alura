
using UnityEngine;

public class ZumbiGeneratorContoller : MonoBehaviour, IGeneratorController
{
    private int timeToNew;
    private LayerMask zumbiLayerMask;
    private string[] noContact = { Utils.SCENE_OBJECT_TAG,Utils.ZUMBI_TAG };

    private void Start() {
        timeToNew = Utils.GetTimeToNew(3);
        zumbiLayerMask = LayerMask.GetMask(noContact);
    }

    // Update is called once per frame
    void FixedUpdate() {

        timeToNew--;

        if(timeToNew > 0) {
            return;
        }

        if(GameObject.FindGameObjectsWithTag(Utils.ZUMBI_TAG).Length > Utils.ZUMBI_MAX) {
            return;
        }

        if(Vector3.Distance(PlayerController.PlayerInstance.transform.position,transform.position) < Utils.MOVE_DISTANCE) {
            return;
        }

       
        CreateInstance();
        
    }

    

    public void SetTimeToNew(int timeToNew) {
        this.timeToNew = timeToNew;
    }

    public Vector3 PositionGenerator() {
         
        return Utils.GetRandomByPosition(transform.position,Utils.SEEK_DISTANCE);
    }

    public void CreateInstance() {
        Vector3 position = PositionGenerator();
        if(Physics.OverlapSphere(position,Utils.IMPACT_DISTANCE,zumbiLayerMask).Length > 0) {
            return;
        }
        int rad = Random.Range(0,13);
        ZumbiController.CreateInstance(rad,position,transform.rotation);
        SetTimeToNew(Utils.GetTimeToNew(rad));
    }
}
