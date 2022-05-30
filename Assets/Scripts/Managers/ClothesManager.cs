using CollectRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoSingleton<ClothesManager>
{
    [Header("Crop")]
    public GameObject[] cropArray = new GameObject[4];
    [Header("Dress")]
    public GameObject[] dressArray = new GameObject[2];
    [Header("Hair")]
    public GameObject[] hairArray = new GameObject[3];
    [Header("Pant")]
    public GameObject[] pantArray = new GameObject[3];
    [Header("Shoes")]
    public GameObject[] shoesArray = new GameObject[3];
    [Header("Skirt")]
    public GameObject[] skirtArray = new GameObject[3];

    private int _cropName = 0;
    public int CropName
    { get { return (int)_cropName; } 
        set { _cropName = value; } }

    private int _dressName = 0;
    public int DressName
    { get { return _dressName; } 
        set { _dressName = value; } }

    private int _hairName = 0;
    public int HairName
    { get { return _hairName; } 
        set { _hairName = value; } }

    private int _pantName = 0;
    public int PantName
    { get { return _pantName; } 
        set { _pantName = value; } }

    private int _shoesName = 0;
    public int ShoesName
    { get { return _shoesName; } 
        set { _shoesName = value; } }

    private int _skirtName = 0;
    public int SkirtName
    { get { return _skirtName; } 
        set { _skirtName = value; } }

    public static ClothesManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shoes"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Ayakkabi" + _shoesName);
            _shoesName = int.Parse(other.gameObject.name);
            for (int i = 0; i < shoesArray.Length; i++)
            {
                if (_shoesName >= 0)
                {
                    shoesArray[i].SetActive(false);
                }         
            }
            shoesArray[_shoesName].SetActive(true);
        }       
        if (other.gameObject.CompareTag("Crop"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Crop" + _cropName);
            _cropName = int.Parse(other.gameObject.name);
            for (int i = 0; i < cropArray.Length; i++)
            {
                cropArray[i].SetActive(false);
                dressArray[_dressName].SetActive(false);
            }
            cropArray[_cropName].SetActive(true);
        }
        if (other.gameObject.CompareTag("Dress"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Dress" + _dressName);
            _dressName = int.Parse(other.gameObject.name);
            for (int i = 0; i < dressArray.Length; i++)
            {
                dressArray[i].SetActive(false);
                cropArray[_cropName].SetActive(false);
                pantArray[_pantName].SetActive(false);
                skirtArray[_skirtName].SetActive(false);

            }
            dressArray[_dressName].SetActive(true);
        }
        if (other.gameObject.CompareTag("Hair"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Hair" + _hairName);
            _hairName = int.Parse(other.gameObject.name);
            for (int i = 0; i < hairArray.Length; i++)
            {
                hairArray[i].SetActive(false);
            }
            hairArray[_hairName].SetActive(true);
        }
        if (other.gameObject.CompareTag("Pant"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Pant" + _pantName);
            _pantName = int.Parse(other.gameObject.name);
            for (int i = 0; i < pantArray.Length; i++)
            {
                pantArray[i].SetActive(false);
                skirtArray[_skirtName].SetActive(false);
                dressArray[_dressName].SetActive(false);
            }
            pantArray[_pantName].SetActive(true);
        }
        if (other.gameObject.CompareTag("Skirt"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Skirt" + _skirtName);
            _skirtName = int.Parse(other.gameObject.name);
            for (int i = 0; i < skirtArray.Length; i++)
            {
                skirtArray[i].SetActive(false);
                dressArray[_dressName].SetActive(false);
                pantArray[_pantName].SetActive(false);
            }
            skirtArray[_skirtName].SetActive(true);
        }
    }
}
