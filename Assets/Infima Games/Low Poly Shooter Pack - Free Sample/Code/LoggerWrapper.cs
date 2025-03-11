using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnityLogger
{ 
    public void Log(string message)
    {
        Debug.Log(message);
    }
    public void LogCollection(IEnumerable<string> collection)
    {
        foreach (string str in collection)
        {
            Log(str);
        }
    }
}

public class LoggerWrapper : MonoBehaviour
{
    private UnityLogger logger = new();
    public UnityLogger Logger => logger;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            List<string> stringsList = new List<string>() { "STR", "StringTwo", "StringThree" };
            string[] stringsArray = new string[] { "STRARR", "StringArrTwo" };
            IEnumerable<string> onlyUpperCase = stringsList.Where(str => str.All(ch => char.IsUpper(ch))); // выбираем те строки, где символы в upperCase

            Logger.LogCollection(stringsList);
            Logger.LogCollection(stringsArray);
            Logger.LogCollection(onlyUpperCase);
        }
    }
}


//task 3.2 - im not find "LogMovable" in the project :( 