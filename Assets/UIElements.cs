using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] GameObject Energy;
    [SerializeField] GameObject Health;
    [SerializeField] int hp = 5;
    [SerializeField] int energy = 5;
    public void DoDamage()
    {
        hp --;
        Health.transform.GetChild(hp).gameObject.SetActive(false);
    }
    public void OnEnergyUse()
    {
        energy --;
        Energy.transform.GetChild(energy).gameObject.SetActive(false);
    }
}
