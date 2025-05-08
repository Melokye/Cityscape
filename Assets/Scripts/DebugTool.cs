using UnityEngine;
using System;
using System.Reflection;

public static class DebugTool
{
    public static void CheckSerializeField(MonoBehaviour someScript){

        Type type = someScript.GetType();

        // Liste tous les champs SerializeField
        FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields){
            if (field.GetValue(someScript) == null)
            {
                Debug.LogError($"[NULL FIELD] {type.Name}.{field.Name} n'est pas assigné dans l'inspecteur", someScript);
            }
        }
    }
}
