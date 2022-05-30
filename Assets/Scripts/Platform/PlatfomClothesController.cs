using CollectRace;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomClothesController : MonoSingleton<PlatfomClothesController>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Player"))
        {
            StartCoroutine("CreateCropAfterCollect");
        }
    }
    public IEnumerator CreateCropAfterCollect1()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Rigidbody>().DOMoveY(0f, 0.1f);
        this.transform.GetChild(0).GetComponent<Transform>().DOScale(1.5f, 1f);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
    public IEnumerator CreateCropAfterCollect()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Rigidbody>().DOMoveY(-1.5f, 0f);
        this.transform.GetChild(0).GetComponent<Transform>().DOScale(0f, 0f);
        StartCoroutine("CreateCropAfterCollect1");
    }

}
