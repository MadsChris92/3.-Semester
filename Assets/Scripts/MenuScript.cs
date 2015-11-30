using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
    public void gotoOverview() {
        Application.LoadLevel("Overview");
    }
    public void gotoStatus() {
        Application.LoadLevel("Status");
    }
    public void gotoShop() {
        Application.LoadLevel("Shop");
    }
    public void gotoLevelSelect() {
        Application.LoadLevel("LevelSelect");
    }
}
