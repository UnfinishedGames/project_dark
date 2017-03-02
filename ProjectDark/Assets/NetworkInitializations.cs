using System.Collections.Generic;
using UnityEngine;

public class NetworkInitializations : MonoBehaviour {

    bool playersAssigned;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 2 && !playersAssigned)
        {
            playersAssigned = true;
            var healthbarSlider1 = GameObject.FindGameObjectWithTag("Healthbar1").GetComponent<UnityEngine.UI.Slider>();
            var healthScript1 = players[0].GetComponent<PlayerHealth>();
            healthScript1.healthBar = healthbarSlider1;

            var healthbarSlider2 = GameObject.FindGameObjectWithTag("Healthbar2").GetComponent<UnityEngine.UI.Slider>();
            var healthScript2 = players[1].GetComponent<PlayerHealth>();
            healthScript2.healthBar = healthbarSlider2;
        }
	}
}
