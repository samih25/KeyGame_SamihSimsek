using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coroutine : MonoBehaviour
{
    [SerializeField] SpriteRenderer _circle1, _circle2, _circle3;
    [SerializeField] Text _info;
    void Start()
    {
        
        StartCoroutine(TrafikLambalari());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Kirmizi()
    {
        _circle1.color = Color.red;
        _info.color = Color.red;
        _info.text = "Dur";

    }
    void Sari()
    {
        _circle2.color = Color.yellow;
        _info.color = Color.yellow;
        _info.text = "Hazirlan";
        

    }
    void Yesil()
    {
        _circle3.color = Color.green;
        _info.color = Color.green;
        _info.text = "Gec";

    }

    IEnumerator TrafikLambalari()
    {
        yield return new WaitForSeconds(3);
        Kirmizi();
        yield return new WaitForSeconds(3);
        _circle1.color = Color.white;
        Sari();
        yield return new WaitForSeconds(3);
        _circle2.color = Color.white;
        Yesil();

    }



}
