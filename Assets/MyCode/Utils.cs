using UnityEngine;
public static class Utils {
    
    public const string GUNPACK_TAG = "GunPack";
    public const int GUNPACK_SIZE = 4;
    public const int ZUMBI_DEFINITION_SIZE = 13;
    public const float IMPACT_DISTANCE = 2.2f;
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

    public static readonly float[] PARKING_LIMITS = new float[2] { 21f,15f };
    

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
       
        float min = Utils.PARKING_LIMITS[0] * -1;
        float max = Utils.PARKING_LIMITS[0];
        float x = Random.Range(min,max);
        min = Utils.PARKING_LIMITS[1] * -1;
        max = Utils.PARKING_LIMITS[1];
        float z = Random.Range(min,max);

        return new Vector3(x,IMPACT_DISTANCE,z);


    }
 
}