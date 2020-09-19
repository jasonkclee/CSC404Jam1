using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public static int ScoreCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Box(new Rect(100, 200, 200, 200), ScoreCount.ToString() );
    }
}
