using UnityEngine;
public static class Utils {


    public const int GUNPACK_MAX = 16;
    public const int GUNPACK_SIZE = 4;
    public const int ZUMBI_DEFINITION_SIZE = 13;
    public const float MOVE_DISTANCE = 32f;
    public const float SEEK_DISTANCE = 14f;
    public const float IMPACT_DISTANCE = 2.3f;
    public const int BULLET_TIME_INIT = 150;
    public const string BUTTON_FIRE = "Fire1";
    public const int ZUMBI_MAX = 175;
    public const string SCENE_PARKING = "Parking";

    public const string SLASH_PATH = "/";
    public const string GUNPACK_PATH = "MyPrefabs/GunPack";
    public const string ZUMBI_PATH = "MyPrefabs/Zumbi";
    public const string ZUMBI_IMAGE_PATH = "MyImages/Zumbi";
    public const string BULLET_PATH = "MyPrefabs/Bullet";

    public const int TIME_TO_NEW_INIT = 850;
    public const int TIME_TO_NEW_GUN = 100;


    public const string SURVIVE_TIME_TEXT = "Survive Time: {0}min:{1}sec";
    public const string SURVIVE_TIME_BEST_TEXT = "Best Survive Time: {0}min:{1}sec";

    public const string SURVIVE_TIME_TAG = "SurviveTime";
    public const string PLAYER_TAG = "Player";
    public const string SCENE_OBJECT_TAG = "SceneObject";
    public const string BASE_FLOOR_TAG = "BaseFloor";
    public const string GUNPACK_TAG = "GunPack";
    public const string ZUMBI_TAG = "Zumbi";
    public const string VERTICAL = "Vertical";
    public const string HORIZONTAL = "Horizontal";

    public const float CAMERA_DELAY = 1.09f;

    public static readonly Vector3 CAMERA_DELAY_POSITION = new(0.10f,29.5f,-28f);

    public static readonly Color[] COLOR_DEFINITION = new Color[GUNPACK_SIZE] {
        new Color(0.2f,0.2f,0.8f),
        new Color(0.8f,0.2f,0.2f),
        new Color(0.8f,0.4f,0.2f),
        new Color(0.2f,0.8f,0.2f)
    };

    public static int GetTimeToNew(int rad) {
        return (rad + 1) * 10;
    }

    

    public static Vector3 GetRandomByPosition(Vector3 position, float limit) {
        position +=  Random.insideUnitSphere * limit;
        position.y = IMPACT_DISTANCE;
        return position;
    }

    public static Sprite GetZumbiSpriteById(int id) {
        return Resources.Load<Sprite>($"{ZUMBI_IMAGE_PATH}{SLASH_PATH}{ZUMBI_TAG}{id}");
    }


}