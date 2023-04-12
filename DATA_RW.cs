using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DATA_RW : MonoBehaviour {
    public string[] player_id;
    public int[] player_score;
    public int player_Rank;
    public int old_player_Rank;
    public Text[] player_id_text;
    public Text[] player_score_text;
    public InputField[] newplayer;
    public GameObject NewScroe;
    // Use this for initialization
    void Start () {
        //只顯示前三名成績
        for (int j = 0; j < player_id.Length-1; j++)
        {
            player_id_text[j].text = PlayerPrefs.GetString("p_id" + j);
            player_score_text[j].text = PlayerPrefs.GetInt("p_score" + j).ToString();
            player_id[j] = PlayerPrefs.GetString("p_id" + j);
            player_score[j] = PlayerPrefs.GetInt("p_score" + j);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void submit_btn()
    {
        string id_temp;
        int score_temp;
        //把新成績放進陣列第4個位置
        player_score[player_score.Length - 1] = int.Parse(newplayer[1].text);
        player_id[player_id.Length - 1] = newplayer[0].text;

        for (int i = player_score.Length - 1; i > 0; i--) //白板上演算法步驟
        {

            if (player_score[i] > player_score[i - 1])
            {
                score_temp = player_score[i - 1];
                id_temp = player_id[i - 1];
                player_score[i - 1] = player_score[i];
                player_id[i - 1] = player_id[i];
                player_score[i] = score_temp;
                player_id[i] = id_temp;
                if (player_id[i] == player_id[1])
                    player_Rank = 1;
                else if (player_id[i] == player_id[2])
                    player_Rank = 2;
                else if (player_id[i] == player_id[3])
                    player_Rank = 3;
                else if (player_id[i] == player_id[4])
                    player_Rank = 4;
                else if (player_id[i] == player_id[5])
                    player_Rank = 5;
                Debug.Log("交換1次");
            }

        }

        for (int j = 0; j < player_id.Length; j++) //把新的排序完陣列寫入系統儲存
        {
            PlayerPrefs.SetString("p_id" + j, player_id[j]);
            PlayerPrefs.SetInt("p_score" + j, player_score[j]);
            Debug.Log("ID" + player_id[j] + "|" + "SCORE" + player_score[j]);
        }

        for (int k = 0; k < player_id.Length - 1; k++) //立即更新畫面排名
        {
            player_id_text[k].text = PlayerPrefs.GetString("p_id" + k);
            player_score_text[k].text = PlayerPrefs.GetInt("p_score" + k).ToString();
        }
        StartCoroutine(RankShow());
    }

    IEnumerator RankShow()
    {
        if (player_Rank !=5 && player_Rank != old_player_Rank || player_Rank==1)
        {
            if (player_Rank == 1)
            {
                NewScroe.SetActive(true);
                NewScroe.transform.position = new Vector3(-3.8f, 5.7f);
                old_player_Rank = player_Rank;
            }
            else if (player_Rank == 2)
            {
                NewScroe.SetActive(true);
                NewScroe.transform.position = new Vector3(-3.8f, 4.6f);
                old_player_Rank = player_Rank;
            }
            else if (player_Rank == 3)
            {
                NewScroe.SetActive(true);
                NewScroe.transform.position = new Vector3(-3.8f, 3.5f);
                old_player_Rank = player_Rank;
            }
            else if (player_Rank == 4)
            {
                NewScroe.SetActive(true);
                NewScroe.transform.position = new Vector3(-3.8f, 2.4f);
                old_player_Rank = player_Rank;
            }
            else if (player_Rank == 5)
            {
                NewScroe.SetActive(true);
                NewScroe.transform.position = new Vector3(-3.8f, 1.1f);
                old_player_Rank = player_Rank;
            }
        }
        yield return new WaitForSeconds(5);
        NewScroe.SetActive(false);
    }
}
