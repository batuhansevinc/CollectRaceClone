using CollectRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoSingleton<WinController>
{
    public bool isWin = false;
    public bool isLose = false;
    public Sprite WinSprite;
    public GameObject confetti;
    public List<GameObject> loseClothes = new List<GameObject>();
    private int _hair;
    private int _crop;
    private int _pant;
    private int _dress;
    private int _skirt;
    private int _shoes;
    [Header("Win Hair")]
    public GameObject hair;
    [Header("Win Crop")]
    public GameObject crop = null;
    [Header("Win Shoes")]
    public GameObject shoes = null;
    [Header("Win Pant")]
    public GameObject pant;
    [Header("Win Dress")]
    public GameObject dress;
    [Header("Win Skirt")]
    public GameObject skirt;
    private GameObject PlatformClothesParent;
    private Transform ptp;
    
    void Start()
    {
        PlatformClothesParent = GameObject.FindGameObjectWithTag("PlatformClothesParent");
        ptp = PlatformClothesParent.transform;
        foreach (Transform child in ptp)
        {
            loseClothes.Add(child.gameObject);
            if (shoes != null)
            {
                if (shoes.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
            if (pant != null)
            {
                if (pant.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
            if (hair != null)
            {
                if (hair.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
            if (crop != null)
            {
                if (crop.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
            if (dress != null)
            {
                if (dress.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
            if (skirt != null)
            {
                if (skirt.transform.name == child.gameObject.transform.name)
                {
                    loseClothes.Remove(child.gameObject);
                }
            }
        }
        if (hair != null && hair.transform.GetSiblingIndex() > 0)
        {
            _hair = hair.transform.GetSiblingIndex();
        }
        if (crop != null && crop.transform.GetSiblingIndex() > 0)
        {
            _crop = crop.transform.GetSiblingIndex();
        }
        if (shoes != null && shoes.transform.GetSiblingIndex() > 0)
        {
            _shoes = shoes.transform.GetSiblingIndex();
        }
        if (pant != null && pant.transform.GetSiblingIndex() > 0)
        {
            _pant = pant.transform.GetSiblingIndex();
        }
        if (dress != null && dress.transform.GetSiblingIndex() > 0)
        {
            _dress = dress.transform.GetSiblingIndex();
        }
        if (skirt != null && skirt.transform.GetSiblingIndex() > 0)
        {
            _skirt = skirt.transform.GetSiblingIndex();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Player") && ModelController.Instance.GetComponent<ModelController>().gameObject == ModelManager.Instance.ModelList[0].gameObject)
        {
            if (_hair > 0 && GetComponent<Transform>().GetChild(_hair).gameObject.activeSelf == true || _crop > 0 && GetComponent<Transform>().GetChild(_crop).gameObject.activeSelf == true ||
               _shoes > 0 && GetComponent<Transform>().GetChild(_shoes).gameObject.activeSelf == true || _pant > 0 && GetComponent<Transform>().GetChild(_pant).gameObject.activeSelf == true ||
               _dress > 0 && GetComponent<Transform>().GetChild(_dress).gameObject.activeSelf == true || _skirt > 0 && GetComponent<Transform>().GetChild(_skirt).gameObject.activeSelf == true)
            {
                ModelAnimationController.Instance.Happy();
                Debug.Log("Close To Win");
                confetti.SetActive(true);
            }
            if (GetComponent<Transform>().GetChild(_hair).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_crop).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_shoes).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_pant).gameObject.activeSelf == true)
            {
                ModelAnimationController.Instance.Catwalk();
                Debug.Log("Win");
                isWin = true;
                confetti.SetActive(true);
            }
            if (GetComponent<Transform>().GetChild(_hair).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_shoes).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_dress).gameObject.activeSelf == true)
            {
                ModelAnimationController.Instance.Catwalk();
                Debug.Log("Win");
                isWin = true;
                confetti.SetActive(true);
            }
            if (GetComponent<Transform>().GetChild(_hair).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_crop).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_shoes).gameObject.activeSelf == true &&
                GetComponent<Transform>().GetChild(_skirt).gameObject.activeSelf == true)
            {
                ModelAnimationController.Instance.Catwalk();
                Debug.Log("Win");
                isWin = true;
                confetti.SetActive(true);
            }
            else
            {
             ModelAnimationController.Instance.Lose();
             Debug.Log("LOSE");
            }
        }
    }
}
