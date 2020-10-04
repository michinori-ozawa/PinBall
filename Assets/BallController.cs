using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

		/// <summary>スコアを格納する変数</summary>
		private int m_score;

		/// <summary>スコアを表示するテキスト</summary>
		private GameObject m_scoreText;


        // Use this for initialization
        void Start ()
        {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");
				// シーン上に "ScoreText" という名前で Text のオブジェクトを作っておく。そこにプログラムからスコアを表示させる。
				this.m_scoreText = GameObject.Find("ScoreText");
        }

        // Update is called once per frame
        void Update ()
        {
                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ)
                {
                        //GameoverTextにゲームオーバを表示
                        this.gameoverText.GetComponent<Text> ().text = "Game Over";
                }
        }
		
		// スクリプトがアタッチされているオブジェクト（ここでは Ball）のコライダーが、他のコライダーに衝突したら呼ばれる（Lesson 5 - 7.2 参照）
		private void OnCollisionEnter(Collision collision)
		{
			// 衝突相手のタグが LargeStarTag の場合、加点する
			if (collision.gameObject.tag == "LargeStarTag")
				{	
				// スコアを20点追加する
				m_score += 20;
				// 表示を更新する
				this.m_scoreText.GetComponent<Text>().text = m_score.ToString();
				}
				
			// 衝突相手のタグが SmllStarTag の場合、加点する
			else if (collision.gameObject.tag == "SmallStarTag")
				{
				// スコアを10点追加する
				m_score += 10;
				// 表示を更新する
				this.m_scoreText.GetComponent<Text>().text = m_score.ToString();
				}
				
			// 衝突相手のタグが SmallCloudTag の場合、加点する
			else if (collision.gameObject.tag == "SmallCloudTag")
				{
				// スコアを50点追加する
				m_score += 50;
				// 表示を更新する
				this.m_scoreText.GetComponent<Text>().text = m_score.ToString();
				}
				
			// 衝突相手のタグが LargeCloudTag の場合、加点する
			else if (collision.gameObject.tag == "LargeCloudTag")
				{
				// スコアを100点追加する
				m_score += 100;
				// 表示を更新する
				this.m_scoreText.GetComponent<Text>().text = m_score.ToString();
				}
				
			else
                {
                }
		}
		
}