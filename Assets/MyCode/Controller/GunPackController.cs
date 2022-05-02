using UnityEngine;

public class GunPackController : MonoBehaviour
{
    
    private int _bulletType;

    public void setBulletType(int bulletType) {
        _bulletType = bulletType;
    }

    private void OnTriggerEnter(Collider other) {
        FireGunController fireGun;
        if(other.TryGetComponent<FireGunController>(out fireGun)) {
            int rad = Random.Range(9,20) * Utils.GUNPACK_SIZE - _bulletType;
            fireGun.SetMunition(rad);
            fireGun.SetBulletType(_bulletType);
            GameObject gunPackGenerator = GameObject.FindGameObjectWithTag(Utils.GUNPACK_TAG);
            gunPackGenerator.GetComponent<GunPackGeneratorController>().SetTimeToNew(Utils.GetTimeToNew(rad));
            Destroy(gameObject);
        }
    }


}
