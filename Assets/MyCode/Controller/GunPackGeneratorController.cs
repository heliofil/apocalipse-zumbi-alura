using UnityEngine;

public class GunPackGeneratorController : MonoBehaviour
{
    
    public GameObject Player;
    public GameObject Gunpack;
    private int _timeToNew;

    public void SetTimeToNew(int timeToNew) {
        _timeToNew = timeToNew;
    }

    private void Start() {
        _timeToNew = 0;
    }

    private void FixedUpdate() {

        if(_timeToNew < 1) {
            int rad = Random.Range(0,Utils.GUNPACK_SIZE);
            NewPosition(rad);
            CreateGunPack(rad);
            _timeToNew = Utils.GetTimeToNew(rad);
        } 

        _timeToNew -= 1;

    }

    private void NewPosition(int rad) {

        Vector2 position = Random.insideUnitCircle * (rad + 9);
        Vector3 distance = Player.transform.position + new Vector3(position.x, position.y, 1) ;
        distance.y = Utils.IMPACT_DISTANCE;
        transform.SetPositionAndRotation(distance,Player.transform.rotation);

    }

    private void CreateGunPack(int rad) {
        GameObject gunpackInstance = Instantiate(Gunpack,transform.position,transform.rotation);
        gunpackInstance.transform.GetChild(rad).gameObject.SetActive(true);
        GunPackController gunPackController = gunpackInstance.GetComponent<GunPackController>();
        gunPackController.setBulletType(rad);
    }


}
