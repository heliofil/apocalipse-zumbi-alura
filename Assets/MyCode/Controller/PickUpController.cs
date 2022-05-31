using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private PicKUpsDomain PicKUps;

    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent(out PlayerController player)) {
            switch(PicKUps.Id) {
                case 0: //MedKit
                player.Restore();
                break;
                case 1: //Lantern
                player.LightOn();
                break;
            }
            Destroy(gameObject);
        }
    }


    private void Start() {
        Destroy(gameObject,PicKUps.Life);
        
    }


    public static void CreateInstance(int id,Vector3 position,Quaternion rotation) {
        PicKUpsDomain picKUps = new(id);
        Instantiate(Resources.Load<GameObject>(picKUps.Path),
            Utils.GetRandomByPosition(position,Utils.IMPACT_DISTANCE)
            ,rotation)
           .GetComponent<PickUpController>().PicKUps = picKUps;
    }

    
}
