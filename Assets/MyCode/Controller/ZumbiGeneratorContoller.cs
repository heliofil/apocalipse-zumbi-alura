using UnityEngine;

public class ZumbiGeneratorContoller : MonoBehaviour
{
    private int timeToNew;

    private void Start() {
        timeToNew = Utils.GetTimeToNew(3);
    }

    // Update is called once per frame
    void FixedUpdate() {

        if(GameObject.FindGameObjectsWithTag(Utils.ZUMBI_TAG).Length > Utils.ZUMBI_MAX) {
            return;
        }

        if(timeToNew < 1) {
            int rad = Random.Range(0,13);
            ZumbiController.CreateInstance(rad,transform.position,transform.rotation);
            timeToNew = Utils.GetTimeToNew(rad);
        }

        timeToNew -= 1;

    }

    


}
