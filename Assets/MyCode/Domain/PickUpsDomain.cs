    public class PicKUpsDomain: BasicDomain {


    private readonly static string[] PICKUPS_NAME = new string[2] {
        "MedKit",
        "Lantern",
    };

    private readonly static int[] PICKUPS_LIFE = new int[2] {
        5,
        8,
    };

    public string Path {
        get; private set;
    }

    public float ShowOff {
            get; private set;
        }


    public PicKUpsDomain(int id, string name, float showOff) : base(id,name,PICKUPS_LIFE[id]) {
        ShowOff = showOff;
        Path = Utils.MYPREFABS_PATH + name;
    }

    public PicKUpsDomain(int id) : this(id,PICKUPS_NAME[id],Utils.PICKUPS_SHOWOFF[id]) {
        
    }


}
