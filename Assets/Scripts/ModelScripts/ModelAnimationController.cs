using CollectRace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimationController : MonoSingleton<ModelAnimationController>
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    public void Happy()
    {
        animator.SetBool("Happy", true);
        StartCoroutine("HappyToidle");
    }
    public IEnumerator HappyToidle()
    {
        yield return new WaitForSeconds(1.8f);
        animator.SetBool("Happy", false);
    }
    public void Lose()
    {
        animator.SetBool("Lose", true);
        StartCoroutine("LoseToidle");
    }
    public IEnumerator LoseToidle()
    {
        yield return new WaitForSeconds(1.8f);
        animator.SetBool("Lose", false);
    }
    public void Catwalk()
    {
        animator.SetBool("Happy", false);
        animator.SetBool("Catwalk", true);
    }
}
