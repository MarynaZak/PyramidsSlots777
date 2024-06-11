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
    // GameObject grey;

    [SerializeField] private Image _imageToFillenergy;

    void Start()
    {
        alert.transform.position = new Vector3(0, 0, -50000);

        //grey = transform.Find("Grey").gameObject; //Dont do that pls(((

        if (!PlayerPrefs.HasKey("energy"))
        {
            PlayerPrefs.SetInt("energy", maxEnergy);
        }

        nowEnergy = PlayerPrefs.GetInt("energy");

        pastEnergy = nowEnergy;
        energyText.text = nowEnergy.ToString() + "/" + maxEnergy.ToString();

        if (nowEnergy == 0)
        {
            alert.transform.position = new Vector3(0, 0, -2);
        }
        else
        {
            alert.transform.position = new Vector3(0, 0, -50000);
        }

        _imageToFillenergy.fillAmount = (float)nowEnergy / (float)maxEnergy;

    }

    void Update()
    {
        //grey.transform.localPosition = new Vector3(6f - 0.6f * ((maxEnergy - nowEnergy) / 10), 0, -1);

        if (nowEnergy != pastEnergy)
        {
            energyText.text = nowEnergy.ToString() + "/" + maxEnergy.ToString();
            pastEnergy = nowEnergy;

            _imageToFillenergy.fillAmount = (float)nowEnergy / (float)maxEnergy;

            if (nowEnergy == 0)
            {
                alert.transform.position = new Vector3(0, 0, -2);
            }
        }
    }
}
