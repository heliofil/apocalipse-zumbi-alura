using UnityEngine;

public class GunPackController:MonoBehaviour {

    private BasicDomain GunPack;

    public static void CreateInstance(int id,Vector3 position) {
        GunPackController newGunPack = Instantiate(Resources.Load<GameObject>(Utils.GUNPACK_PATH))
            .GetComponent<GunPackController>();
        newGunPack.GunPack = new BasicDomain(id,Utils.GUNPACK_PATH,(30 - (id * 4)));
        newGunPack.transform.position = position;
        newGunPack.transform.GetChild(0).GetChild(id).gameObject.SetActive(true);
    }


    private void Start() {
        Destroy(gameObject,GunPack.Life);
    }

    private void OnTriggerEnter(Collider other) {
        FireGunController fireGun = other.GetComponentInChildren<FireGunController>();
        if(fireGun != null) {
            fireGun.MunitionZero();
            fireGun.DefineById(GunPack.Id);
            Destroy(gameObject);
        }

    }


}
