using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System.IO;

public class Data_io : MonoBehaviour {
    string m_FileName_1;                             //法二要用
    string m_FileName_2;
    string[] strs_1;                                //法二要用
    string[] strs_2;
    public Text[] player_id_text;
    public Text[] player_score_text;

    // Use this for initialization
    void Start () {
        m_FileName_1 = "Player_ID.txt";
        m_FileName_2 = "Player_SCORE.txt";
        ReadFile(m_FileName_1, m_FileName_2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void sure_btn ()
    {
        
    }

    void ReadFile(string FileName_1, string FileName_2)
    {
        strs_1 = File.ReadAllLines(FileName_1);//读取文件的所有行，并将数据读取到定义好的字符数组strs中，一行存一个单元
        strs_2 = File.ReadAllLines(FileName_2);
        for (int i = 0; i < strs_1.Length-1; i++)
        {
            player_id_text[i].text = strs_1[i];//读取每一行，并连起来
            player_score_text[i].text = strs_2[i];

        }
    }

}
