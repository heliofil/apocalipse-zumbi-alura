using UnityEngine;

public class GunPackController:MonoBehaviour {
    
    private int bulletType;

    public static void CreateInstanceById(int id) {
        GunPackController newGunPack = Instantiate(Resources.Load<GameObject>(Utils.GUNPACK_PATH))
            .GetComponent<GunPackController>();
        newGunPack.bulletType = id;
        newGunPack.transform.position = Utils.GetRandomPosition();
        newGunPack.transform.GetChild(0).GetChild(id).gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        FireGunController fireGun = other.GetComponentInChildren<FireGunController>();
        if(fireGun != null) {
            fireGun.MunitionZero();
            fireGun.DefineById(bulletType);
            Destroy(gameObject);
        }

    }


}
