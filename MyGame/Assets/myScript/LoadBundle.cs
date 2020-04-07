using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class LoadBundle : MonoBehaviour
{
    // Start is called before the first frame update
    public string Bundlename;
    public string SceneName;

    private void Start()
    {
        StartCoroutine("Load");
    }
    IEnumerator Load()
    {
        /*
         */
        using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://yadi.sk/d/tO7nQSr87UC28Q/" + Bundlename))
        {
            //ttps://yadi.sk/d/tO7nQSr87UC28Q/
            yield return www.SendWebRequest();
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }
            SceneManager.LoadScene(SceneName);
            yield return null;
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
