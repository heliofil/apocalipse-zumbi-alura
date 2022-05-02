using UnityEngine;

public class ZumbiGeneratorContoller : MonoBehaviour
{
    public GameObject Zumbi;
    private int _timeToNew;

    private void Start() {
        _timeToNew = Utils.GetTimeToNew(3);
    }

    // Update is called once per frame
    void FixedUpdate() {

        if(GameObject.FindGameObjectsWithTag(Utils.ZUMBI_TAG).Length > Utils.ZUMBI_MAX) {
            return;
        }

        if(_timeToNew < 1) {
            int rad = Random.Range(0,13);
            CreateZumbi(rad);
            _timeToNew = Utils.GetTimeToNew(rad);
        }

        _timeToNew -= 1;


    }

    private void CreateZumbi(int rad) {
        
        GameObject zumbiInstance = Instantiate(Zumbi,transform.position,transform.rotation);
        ZumbiController zumbiController = zumbiInstance.GetComponent<ZumbiController>();
        zumbiController.DefineZumbiById(rad);
    }


}
