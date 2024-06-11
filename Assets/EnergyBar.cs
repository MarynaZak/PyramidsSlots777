using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Text energyText;
    int maxEnergy = 100;
    public int nowEnergy;
    int pastEnergy;
    public GameObject alert;
    GameObject grey;

    void Start()
    {
        alert.transform.position = new Vector3(0, 0, -50000);

        grey = transform.Find("Grey").gameObject;

        if(!PlayerPrefs.HasKey("energy"))
        {
            PlayerPrefs.SetInt("energy", maxEnergy);
        }

        nowEnergy = PlayerPrefs.GetInt("energy");

        pastEnergy = nowEnergy;
        energyText.text = nowEnergy.ToString()+"/"+maxEnergy.ToString();

        if(nowEnergy == 0)
        {
            alert.transform.position = new Vector3(0, 0, -2);
        }
        else{
            alert.transform.position = new Vector3(0, 0, -50000);
        }
    }

    void Update()
    {
        grey.transform.localPosition = new Vector3(6f-0.6f*((maxEnergy-nowEnergy)/10), 0, -1);

        if(nowEnergy != pastEnergy)
        {
            energyText.text = nowEnergy.ToString()+"/"+maxEnergy.ToString();
            pastEnergy = nowEnergy;
            if(nowEnergy == 0)
            {
                alert.transform.position = new Vector3(0, 0, -2);
            }
        }
    }
}
