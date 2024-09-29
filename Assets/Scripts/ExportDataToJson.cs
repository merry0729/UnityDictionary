using System.IO;
using UnityEngine;

public class ExportDataToJson : MonoBehaviour
{
    [SerializeField] private bool isOn;
    
    public void ExportLogsToJson(ExportData data)
    {
        string folderPath = Path.Combine(Application.dataPath, "../CollectingDataLogs");
        string filePath = Path.Combine(folderPath, $"DataCollect_{System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.json");
        string json       = "";

        json += "--------------[ Provide ]--------------\n";
        
        json += JsonUtility.ToJson(data.totalProvideContainer, true);
        
        json += "\n--------------[ Take ]--------------\n";
        
        json += JsonUtility.ToJson(data.totalTakeContainer, true);
        
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        File.WriteAllText(filePath, json);
        Debug.Log($"Logs exported to {filePath}");
    }
}

 public class ExportData
 {
     public CollectingDamageDataContainer totalProvideContainer;
     public CollectingDamageDataContainer totalTakeContainer;
     
     public ExportData()
     {
         totalProvideContainer = new CollectingDamageDataContainer();
         totalTakeContainer = new CollectingDamageDataContainer();
     }
 }

 public class CollectingDamageDataContainer
 {
     public string DataName;
     
     public float TotalDamage;
     public float TotalCriticalDamage;
     
     public float AverageDamage;
     public float AverageCriticalDamage;
     
     public float MinDamage;
     public float MaxDamage;
     
     public float MinCriticalDamage;
     public float MaxCriticalDamage;
     
     public int HitCount;
     public int CriticalHitCount;
 }