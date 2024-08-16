using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class JsonData : MonoBehaviour
{
    [SerializeField]
    private Button jsonOutput = null;

    [SerializeField]
    private Button loadJson = null;
    [SerializeField]
    private MapManager _mapManager = null;
    
    [SerializeField]
    private FileControllor fileControllor = null;

    private string filePath = "";
    //private string saveFileName = "JsonTest.json";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(null != jsonOutput, "_jsonOutput");
        Debug.Assert(null != loadJson, "_loadJson");
       
        jsonOutput.onClick.AddListener(OnClickJsonOutput);
        loadJson.onClick.AddListener(OnClickLoadJson);
        //filePath = Path.Combine(Application.dataPath, "testdata/"+saveFileName);

    }

    private void OnClickJsonOutput()
    {
        Debug.Log("a");

        Debug.Log(Application.dataPath);

        fileControllor.SaveProject();
        Debug.Log("b");
        Debug.Log(Application.dataPath);

        filePath = fileControllor.filepath;

        Debug.Log("filePath=" + filePath);

        var json = JsonUtility.ToJson(_mapManager.DungeonMapData, false);
        File.WriteAllText(filePath, json);

        

    }

    private void OnClickLoadJson()
    {
        fileControllor.OpenProject();
        filePath = fileControllor.filepath;

        Debug.Log("filePath=" + filePath);
        if (!File.Exists(filePath))
            return;
        var json = File.ReadAllText(filePath);
        _mapManager.DungeonMapData = JsonUtility.FromJson<MapData>(json);

        SceneManager.LoadScene("MapEditor");
        //再次载入


        //_mapManager.RedrawMap();



        //id 同时

      // _mapManager.RedrawEventMessage();

    }

    // Update is called once per frame
    private void OnDestroy()
    {
        jsonOutput.onClick.RemoveAllListeners();
        loadJson.onClick.RemoveAllListeners();
    }
}
