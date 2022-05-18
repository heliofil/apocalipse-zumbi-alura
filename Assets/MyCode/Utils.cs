using UnityEngine;
public static class Utils {
    
    public const string GUNPACK_TAG = "GunPack";
    public const int GUNPACK_SIZE = 4;
    public const int ZUMBI_DEFINITION_SIZE = 13;
    public const float IDLE_DISTANCE = 22f;
    public const float MOVE_DISTANCE = 10f;
    public const float SEEK_DISTANCE = 7f;
    public const float IMPACT_DISTANCE = 2f;
    public const int BULLET_TIME_INIT = 150;
    public const string BUTTON_FIRE = "Fire1";
    public const int ZUMBI_MAX = 75;
    public const string SCENE_PARKING = "Parking";

    public const string GUNPACK_PATH = "MyPrefabs/GunPack";
    public const string ZUMBI_PATH = "MyPrefabs/Zumbi";
    public const string BULLET_PATH = "MyPrefabs/Bullet";

    public const int TIME_TO_NEW_INIT = 850;
    public const int TIME_TO_NEW_GUN = 100;

  
    public const string PLAYER_TAG = "Player";
    public const string ZUMBI_TAG = "Zumbi";
    public const float CAMERA_DELAY = 1.025f;
    public const string VERTICAL = "Vertical";
    public const string HORIZONTAL = "Horizontal";

    public static readonly float SPHERE_LIMITS = 20f ;
    

    public static readonly Color[] COLOR_DEFINITION = new Color[GUNPACK_SIZE] {
        new Color(0.2f,0.2f,0.8f),
        new Color(0.8f,0.2f,0.2f),
        new Color(0.8f,0.4f,0.2f),
        new Color(0.2f,0.8f,0.2f)
    };

    public static int GetTimeToNew(int rad) {
        return (5 * (rad +1)) * 10;
    }

    public static Vector3 GetRandomPosition() {

        Vector3 position = Random.insideUnitSphere * SPHERE_LIMITS;
        position.y = IMPACT_DISTANCE;
        return position;


    }
 
}