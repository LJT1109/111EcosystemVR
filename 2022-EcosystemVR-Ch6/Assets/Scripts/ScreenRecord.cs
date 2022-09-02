using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System.Net;
using System.Threading;

public class ScreenRecord : MonoBehaviour
{
    public string url="www.ylw.idv.tw";
    public string sid="dct";
    public float RefreshPeroid=2.0f; //sec
    public int MaxSerial = 1; //伺服器最多儲存的畫面數量
    //public Text mes; //除錯用
    int ser = 0;
    float pt;
    
    Texture2D newScreenshot;
    byte[] bytes;

    float testt;

    // Start is called before the first frame update
    void Start()
    {
        sid = sid + Random.Range(1, 10);
        testt = Time.time;             
    }
        
    IEnumerator WebUpload(int nser)
    {
        yield return new WaitForEndOfFrame();
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        Texture2D newScreenshot = ScaleTexture(screenshot, Screen.width / 2, Screen.height / 2);

        byte[] bytes = newScreenshot.EncodeToPNG();     
        WWWForm form = new WWWForm();
        form.AddField("SID",sid);
        form.AddField("SNUM", nser);
        form.AddBinaryData("files", bytes, nser+".png", "image/png");

        UnityWebRequest req = UnityWebRequest.Post("https://"+url+"/vrmonitor/Uploader.php", form);
        req.SetRequestHeader("Access-Control-Allow-Origin", "*");
        yield return req.SendWebRequest();

        Destroy(screenshot);
        Destroy(newScreenshot);

        if (req.result == UnityWebRequest.Result.ConnectionError)
            Debug.Log(req.error);
        else
            Debug.Log(req.downloadHandler.text);
    }

    void Update()
    {
        if (Time.time - pt > RefreshPeroid)
        {
            pt = Time.time;
            //StartCoroutine(Capture());
            StartCoroutine(WebUpload(ser));
            ser++;
            if (ser >= MaxSerial) 
            { 
                ser = 0; 
                //mes.text = sid.ToString()+"  "+(Time.time - testt).ToString();  //除錯用
                testt = Time.time; 
            }
        }
    }

    private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
        Color[] rpixels = result.GetPixels(0);
        float incX = ((float)1 / source.width) * ((float)source.width / targetWidth);
        float incY = ((float)1 / source.height) * ((float)source.height / targetHeight);
        for (int px = 0; px < rpixels.Length; px++)
        {
            rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth),
                              incY * ((float)Mathf.Floor(px / targetWidth)));
        }
        result.SetPixels(rpixels, 0);
        result.Apply();
        return result;
    }

    /*IEnumerator FTPUpload() //for PC
   {
       string path = Application.temporaryCachePath + "/temp.png";
       bool isUploading = false;

       UnityEngine.Debug.Log("開始！！");

       ThreadPool.QueueUserWorkItem((o) =>
       {
           using (WebClient client = new WebClient())
           {
               client.Credentials = new NetworkCredential("ylw", "1234");
               client.UploadFile("ftp://" + url + "/" + sid + ".png", "STOR", path);
           }
           isUploading = true;
       });

       while (!isUploading)
       {
           UnityEngine.Debug.Log("上傳中！！");
           yield return new WaitForSeconds(0.1f);
       }

       UnityEngine.Debug.Log("結束！！");
   }
   IEnumerator UploadMultipleFiles()
   {
       string[] path = new string[3];
       path[0] = "D:/File1.txt";
       path[1] = "D:/File2.txt";
       path[2] = "D:/File3.txt";

       UnityWebRequest[] files = new UnityWebRequest[path.Length];
       WWWForm form = new WWWForm();

       for (int i = 0; i < files.Length; i++)
       {
           files[i] = UnityWebRequest.Get(path[i]);
           yield return files[i].SendWebRequest();
           form.AddBinaryData("files[]", files[i].downloadHandler.data, Path.GetFileName(path[i]));
       }

       UnityWebRequest req = UnityWebRequest.Post("http://localhost/File%20Upload/Uploader.php", form);
       yield return req.SendWebRequest();

       if (req.result == UnityWebRequest.Result.ConnectionError)
           Debug.Log(req.error);
       else
           Debug.Log("Uploaded " + files.Length + " files Successfully");
   }

   IEnumerator Capture()
   {
       //ScreenCapture.CaptureScreenshot(Application.temporaryCachePath + "/temp.png");        
       fileData = File.ReadAllBytes(Application.temporaryCachePath + "/temp.png");
       tex = new Texture2D(2, 2);
       tex.LoadImage(fileData);
       newScreenshot=ScaleTexture(tex, Screen.width / 2, Screen.height / 2);
       bytes = newScreenshot.EncodeToPNG();
       File.WriteAllBytes(Application.temporaryCachePath + "/temp.png", bytes);
       yield return new WaitForEndOfFrame();
       Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
       screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
       screenshot.Apply();

       Texture2D newScreenshot = ScaleTexture(screenshot, Screen.width/2, Screen.height/2);

       byte[] bytes = newScreenshot.EncodeToPNG();
       //File.WriteAllBytes(Application.temporaryCachePath + "/temp.png", bytes);
   }
*/
}
