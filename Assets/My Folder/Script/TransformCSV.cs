using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCSV : MonoBehaviour
{

    [SerializeField] Transform Right_controler_transform;

    private StreamWriter sw;

    float time = 0.0f;

    // Update is called once per frame
    void Start()
    {
        sw = new StreamWriter(@"Assets/My Folder/SaveData.csv", false, Encoding.GetEncoding("Shift_JIS"));
        string[] s1 = { "X", "Y", "Z"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);

        // StartCoroutine("WriteCSV");
    }

    public void SaveData(string txt1, string txt2, string txt3)
    {
        string[] s1 = { txt1, txt2, txt3 };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
    }

    // Update is called once per frame
    void Update()
    {

        string RightX = Right_controler_transform.position.x.ToString();
        string RightY = Right_controler_transform.position.y.ToString();
        string RightZ = Right_controler_transform.position.z.ToString();

        Debug.Log(RightX);

        SaveData(RightX, RightY, RightZ);
        
        
    }

    IEnumerator WriteCSV()
    {
        string RightX = Right_controler_transform.position.x.ToString();
        string RightY = Right_controler_transform.position.y.ToString();
        string RightZ = Right_controler_transform.position.z.ToString();

        Debug.Log(RightX);

        SaveData(RightX, RightY, RightZ);

        //0.1ïbí‚é~
        yield return new WaitForSeconds(0.1f);

    }
}
