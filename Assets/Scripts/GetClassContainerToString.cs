using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

public class GetClassContainerToString : MonoBehaviour
{
    public string GetContainerNamesAndValues()
    {
        FieldInfo[]   fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            
        StringBuilder result = new StringBuilder();
            
        foreach (FieldInfo field in fields)
        {
            string name          = field.Name;           
            object value         = field.GetValue(this);

            result.AppendLine($"{name} : {value}");
        }
            
        return result.ToString();
    }
}
