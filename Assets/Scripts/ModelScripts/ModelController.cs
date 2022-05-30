using CollectRace;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ModelController : MonoSingleton<ModelController>
{
    public static ModelController instance;
    ClothesManager ClothesManager;
    private int CropName;
    private int DressName;
    private int HairName;
    private int PantName;
    private int ShoesName;
    private int SkirtName;
    [Header("Default Clothes")]
    public GameObject Bra;
    public GameObject Panties;
    public GameObject Hair;
    public bool isCurrentModel = false;

    private void LateUpdate()
    {
        if (ModelManager.Instance.ModelList[0].gameObject == this.gameObject)
        {
            isCurrentModel = true;
        }
        if (WinController.Instance.isWin == true && isCurrentModel == true)
        {
            Catwalk();
            WinController.Instance.isWin = false;
            WinController.Instance.confetti.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Player") && isCurrentModel == true)
        {
            CropName = ClothesManager.instance.CropName;
            DressName = ClothesManager.instance.DressName;
            HairName = ClothesManager.instance.HairName;
            PantName = ClothesManager.instance.PantName;
            ShoesName = ClothesManager.instance.ShoesName;
            SkirtName = ClothesManager.instance.SkirtName;
            #region //Shoes Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().shoesArray[ShoesName].activeInHierarchy == true)
            {               
                for (int i = 0; i < GetComponent<ClothesManager>().shoesArray.Length; i++)
                {
                    if (ShoesName >= 0)
                    {
                        GetComponent<ClothesManager>().shoesArray[i].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().shoesArray[ShoesName].SetActive(false);
                    }
                }
                GetComponent<ClothesManager>().shoesArray[ShoesName].SetActive(true);                
            }
            #endregion
            #region //Crop Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().cropArray[CropName].activeInHierarchy == true)
            {
                for (int i = 0; i < GetComponent<ClothesManager>().cropArray.Length; i++)
                {
                    if (CropName >= 0)
                    {
                        if (GetComponent<ClothesManager>().pantArray[PantName].activeInHierarchy == false && GetComponent<ClothesManager>().skirtArray[SkirtName].activeInHierarchy == false)
                        {
                            Panties.SetActive(true);
                        }
                        Bra.SetActive(false);
                        GetComponent<ClothesManager>().cropArray[i].SetActive(false);
                        GetComponent<ClothesManager>().dressArray[DressName].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().cropArray[CropName].SetActive(false);                       
                    }
                }
                GetComponent<ClothesManager>().cropArray[CropName].SetActive(true);
            }
            #endregion
            #region //Dress Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().dressArray[DressName].activeInHierarchy == true)
            {
                for (int i = 0; i < GetComponent<ClothesManager>().dressArray.Length; i++)
                {
                    if (DressName >= 0)
                    {
                        Bra.SetActive(false);
                        Panties.SetActive(false);
                        GetComponent<ClothesManager>().dressArray[i].SetActive(false);
                        GetComponent<ClothesManager>().cropArray[CropName].SetActive(false);
                        GetComponent<ClothesManager>().pantArray[PantName].SetActive(false);
                        GetComponent<ClothesManager>().skirtArray[SkirtName].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().dressArray[DressName].SetActive(false);                        
                    }
                }
                GetComponent<ClothesManager>().dressArray[DressName].SetActive(true);
            }
            #endregion
            #region //Hair Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().hairArray[HairName].activeInHierarchy == true)
            {
                for (int i = 0; i < GetComponent<ClothesManager>().hairArray.Length; i++)
                {
                    if (HairName >= 0)
                    {
                        Hair.SetActive(false);
                        GetComponent<ClothesManager>().hairArray[i].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().hairArray[HairName].SetActive(false);
                    }
                }
                GetComponent<ClothesManager>().hairArray[HairName].SetActive(true);
            }
            #endregion
            #region //Pant Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().pantArray[PantName].activeInHierarchy == true)
            {
                for (int i = 0; i < GetComponent<ClothesManager>().pantArray.Length; i++)
                {
                    if (PantName >= 0)
                    {
                        if (GetComponent<ClothesManager>().dressArray[DressName].activeInHierarchy == false && GetComponent<ClothesManager>().cropArray[CropName].activeInHierarchy == false)
                        {
                            Bra.SetActive(true);
                        }
                        Panties.SetActive(false);
                        GetComponent<ClothesManager>().pantArray[i].SetActive(false);
                        GetComponent<ClothesManager>().dressArray[DressName].SetActive(false);
                        GetComponent<ClothesManager>().skirtArray[SkirtName].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().pantArray[PantName].SetActive(false);
                    }
                }
                GetComponent<ClothesManager>().pantArray[PantName].SetActive(true);
            }
            #endregion
            #region //Skirt Set Active Changer//
            if (PlayerController.Instance.GetComponent<ClothesManager>().skirtArray[SkirtName].activeInHierarchy == true)
            {
                for (int i = 0; i < GetComponent<ClothesManager>().skirtArray.Length; i++)
                {
                    if (SkirtName >= 0)
                    {
                        if (GetComponent<ClothesManager>().dressArray[DressName].activeInHierarchy == false && GetComponent<ClothesManager>().cropArray[CropName].activeInHierarchy == false)
                        {
                            Bra.SetActive(true);
                        }
                        Panties.SetActive(false);
                        GetComponent<ClothesManager>().skirtArray[i].SetActive(false);
                        GetComponent<ClothesManager>().pantArray[PantName].SetActive(false);
                        GetComponent<ClothesManager>().dressArray[DressName].SetActive(false);
                        PlayerController.Instance.GetComponent<ClothesManager>().skirtArray[SkirtName].SetActive(false);
                    }
                }
                GetComponent<ClothesManager>().skirtArray[SkirtName].SetActive(true);
            }
            #endregion
            
        }      
    }
    public void Catwalk()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(new Vector3(2.3f, 0f, 7.91f), 2)).Append(transform.DORotate(new Vector3(0, -360, 0), 2))
            .Append(transform.DOMove(new Vector3(2.3f, 0f, 40.7f), 4.5f));
    }
}
