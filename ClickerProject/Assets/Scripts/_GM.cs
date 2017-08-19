using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class _GM : MonoBehaviour
{
    public bool menuFlip = false;
    public GameObject menu;

    public Text
        TPS, //Tap Counter
        currentLevelText, //Current Level
        currentXPText, //Current XP
        currentDamageText, //Current Damage
        currentMultiplierText, //Current Multiplier
        currentCoinText; //Coin Display

    // Use this for initialization
    void Start ()
    {
        if(PlayerPrefs.HasKey("MenuSide"))
            if (PlayerPrefs.GetInt("MenuSide") == 0)
                menu.transform.SetAsLastSibling();
            else if (PlayerPrefs.GetInt("MenuSide") == 1)
                menu.transform.SetAsFirstSibling();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClickaPerSecond();

		if(Input.GetKeyDown(KeyCode.Tab))
            SwitchFlip();

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if(Input.GetKeyDown(KeyCode.Delete))
            PlayerPrefs.DeleteAll();

        //if (Input.GetKey(KeyCode.Q))
        //    PlayerStats.coins += 100;

        //if (Input.GetKeyDown(KeyCode.M))
        //    PlayerStats.coins = 999998;
    }

    public void SwitchFlip()
    {
        menuFlip = !menuFlip;

        if (menuFlip)
        {
            PlayerPrefs.SetInt("MenuSide", 0);
            menu.transform.SetAsLastSibling();
        }
        else
        {
            PlayerPrefs.SetInt("MenuSide", 1);
            menu.transform.SetAsFirstSibling();
        }
    }

    private List<float> taps = new List<float>();
    public float tapsPerSecond;

    void ClickaPerSecond()
    {
        //foreach (Touch touch in Input.touches)
        //{
            //if (touch.phase == TouchPhase.Ended)
                if(Input.GetMouseButtonUp(0))
                taps.Add(Time.timeSinceLevelLoad);
        //}
        for (int i = 0; i < taps.Count; i++)
        {
            if (taps[i] <= Time.timeSinceLevelLoad - 1)
            {
                //taps.Remove(i);
                taps.RemoveAt(i);
            }
        }
        tapsPerSecond = taps.Count;

        TPS.text = "TPS: " + tapsPerSecond.ToString();
        currentCoinText.text = "Coins: " + PlayerStats.coins.ToString();
        currentDamageText.text = "DMG: " + PlayerStats.currentDamage.ToString();
        currentLevelText.text = "LVL: " + PlayerStats.currentLevel.ToString();
        currentMultiplierText.text = "MLTI: " + PlayerStats.damageMultiplier.ToString();
        currentXPText.text = "XP: " + PlayerStats.currentXP.ToString();
    }
}