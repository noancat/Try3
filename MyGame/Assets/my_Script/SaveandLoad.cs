using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SaveandLoad : MonoBehaviour
{
    // Start is called before the first frame update

    public string file;
    public List<GameObject> EnemySaves = new List<GameObject>();
    public List<GameObject> PlayerSaves = new List<GameObject>();
    public Timer TimeToDeth;
    public Doorscript InRoom;
    public Coin coinData;
    string json;
    public void Start()
    {
        file = "C:/Users/игорь/22227/save.xml";
        //TimeToDeth = GetComponent<Timer>();
    }
    public void Savegame()
    {
        XmlSerializer xml = new XmlSerializer((typeof(Save)));
        Save save = new Save();

        save.SaveEnemies(EnemySaves);
        save.SavePlayer(PlayerSaves);
        save.HP = Hpbar.fill;
        save.gameTimer = TimeToDeth.GameTimer;
        save.getCoin = Coin.coinb;
        save.eventSave = Move.patrolAlarm;
        /*
             json = JsonUtility.ToJson(save);
        
        
        using (StreamWriter sw = new StreamWriter("Json.json", false, System.Text.Encoding.Default))
        {
             sw.WriteLineAsync(json);
        }
       */
        using (var stream = new FileStream("Test.xml", FileMode.Create, FileAccess.Write))
        {
            xml.Serialize(stream, save);
        }
        ///print(json);
    }
    public void Loadgame()
    {

        XmlSerializer xml = new XmlSerializer((typeof(Save)));
        Save save = new Save();
        /*
        save = JsonUtility.FromJson<Save>(json);
        */
        using (var stream = new FileStream("Test.xml", FileMode.Open, FileAccess.Read))
        {
            save = xml.Deserialize(stream) as Save;
        }
        int i = 0;
        foreach (var enemy in save.EnemiesDate)
        {
            EnemySaves[i].GetComponent<Patrol>().LoadDate(enemy);

            i++;
        }
        int j = 0;
        foreach (var player in save.PlayerDate)
        {
            PlayerSaves[j].GetComponent<Move>().LoadDate(player);
            j++;
        }
        Hpbar.fill = save.HP;
        TimeToDeth.GameTimer = save.gameTimer;
        Coin.coinb = save.getCoin;
        Move.patrolAlarm = save.eventSave;
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec2
    {
        public float x, y;
        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    [System.Serializable]
    public struct SaveDate
    {
        public Vec2 Position;
        public bool Live;
        public SaveDate(Vec2 pos, bool alive)
        {
            Position = pos;
            Live = alive;
        }
    }
    public List<SaveDate> EnemiesDate = new List<SaveDate>();
    public List<SaveDate> PlayerDate = new List<SaveDate>();

    public float gameTimer;
    public float HP;
    public bool getCoin;
    public bool eventSave;
    public void SavePlayer(List<GameObject> player)
    {
        foreach (var go in player)
        {

            Vec2 pos = new Vec2(go.transform.position.x, go.transform.position.y);
            bool alive = new bool();

            PlayerDate.Add(new SaveDate(pos, alive));
        }
    }
    public void SaveEnemies(List<GameObject> enemies)
    {
        foreach (var go in enemies)
        {
            Patrol pt = go.GetComponent<Patrol>();

            Vec2 pos = new Vec2(go.transform.position.x, go.transform.position.y);
            bool alive = pt.isDead;
            EnemiesDate.Add(new SaveDate(pos, alive));
        }
    }

}
