using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public GameObject SpeedPowerUp;
    public GameObject Shield;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Varp1 = Instantiate(SpeedPowerUp, SpeedPowerUp.transform.position, Quaternion.identity);
        Varp1.GetComponent<SpeedPowerUp>().player = Player;
        //        Debug.Log(Varp1.GetComponent<SpeedPowerUp>().player.name);
        GameObject Varp2 = Instantiate(Shield, Shield.transform.position, Quaternion.identity);
        Varp2.GetComponent<ShieldPowerUp>().player = Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
