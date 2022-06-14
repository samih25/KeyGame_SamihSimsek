using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjeOdev : MonoBehaviour
{
   [SerializeField] SpriteRenderer _karekter,_sariAnahtar,_kirmiziAnahtar,_kapi;
    [SerializeField] GameObject _duvar,_saributton,_kirmizibutton,_AciklamaText;
    [SerializeField] float _speed;
    [SerializeField] Text _anahtarBulText, _anahtarText;

    string[] _oyun = new string[2];
 void Hareket()
    {
       _karekter.transform.position += new Vector3(Input.GetAxis("Horizontal")*_speed*Time.deltaTime, 0);
      
        if (Input.GetKey(KeyCode.D))
        {
            _karekter.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _karekter.flipX = true;
        }
    }
    
    private void FixedUpdate()
    {
        Hareket();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kapi")
        {
            Destroy(_duvar);
            if (_oyun[0] == null)
            {
                Destroy(_duvar);
                _anahtarBulText.text = "Lutfen Anahtar Bul";
            }
            if (_oyun[0]=="Kirmizi Anahtar"&&_oyun[1]==null)
            {
                _anahtarBulText.text = "Yanlis Anahtar";
            }
            if (_oyun[0] == "Kirmizi Anahtar" && _oyun[1] == "Sari Anahtar")
            {
                _saributton.SetActive  (true);
                _kirmizibutton.SetActive(true);
                _AciklamaText.SetActive(true);
                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Sari Anahtar")
        {
            _oyun[1] = "Sari Anahtar";
            _anahtarText.text = "Sari Anahtar Alýndý";

        }
        
        if (collision.gameObject.tag =="Kirmizi Anahtar")
        {
            _oyun[0] = "Kirmizi Anahtar";
            _anahtarText.text = "Kirmizi Anahtar Alýndý";
        }
    }
   public void saributton()
    {
        Destroy(_kapi);
        _saributton.SetActive(false);
        _kirmizibutton.SetActive(false);
        _AciklamaText.SetActive(false);
        _anahtarBulText.text = "";
    }
   public void kirmizibutton()
    {
        _anahtarBulText.text = "Yanlis Anahtar";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Sari Anahtar"|| collision.gameObject.tag == "Kirmizi Anahtar")
        {
            _anahtarText.text = "";
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _anahtarBulText.text = "";
    }
}