using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BossManager : Singleton<BossManager> {

    public Transform player;
    public GameObject boss;
    public float attackDelay = 5f;
    public Transform tangan;
    public Transform kaki;
    public Transform tanganPoint;
    public Transform kakiPoint;
    public Transform kepalaPoint;
    public GameObject torpedo;
    public AudioSource bgm;
    public AudioClip bossClip;
    public GameObject hitFx;
    public GameObject fadeout;
    private bool readyToFight = false;

    private void Awake()
    {
        instance = this;
    }

    void Start () {
       
	}

	void Update () {
		
	}

    public void SpawnBoss()
    {
        bgm.clip = bossClip;
        bgm.Play();
        boss.SetActive(true);
        StartCoroutine(BossIntro());
    }

    IEnumerator BossIntro()
    {
        AlertManager.Instance.ShowAlert();
        yield return new WaitForSeconds(3f);
        boss.transform.DOLocalMoveY(-10f, 2f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutElastic);
        yield return new WaitForSeconds(4f);
        boss.transform.DOScale(new Vector3(2f, 2f), 3f).SetEase(Ease.InOutElastic);
        boss.transform.DOLocalMove(new Vector3(5f, 0, 10f), 2f).SetEase(Ease.InOutFlash);
        readyToFight = true;
        StartCoroutine(AttackPattern());
    }

    IEnumerator AttackPattern()
    {
        yield return new WaitForSeconds(attackDelay);
        tangan.DORotate(new Vector3(0, 0, -35f), 0.5f).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        yield return new WaitForSeconds(attackDelay);
        kaki.DORotate(new Vector3(0, 0, -45f), 0.5f).SetEase(Ease.InOutQuad).SetLoops(2, LoopType.Yoyo);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);


        yield return new WaitForSeconds(attackDelay);
        tangan.DORotate(new Vector3(0, 0, -90f), 0.25f).SetEase(Ease.Linear).SetLoops(20, LoopType.Incremental);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        tangan.DORotate(new Vector3(0, 0, -3f), 0.25f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(attackDelay);
        kaki.DORotate(new Vector3(0, 0, -90f), 0.25f).SetEase(Ease.Linear).SetLoops(20, LoopType.Incremental);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        kaki.DORotate(new Vector3(0, 0, -17f), 0.25f).SetEase(Ease.Linear);

        StartCoroutine(StartDestruction());
        boss.transform.DORotate(new Vector3(0, 90f), 0.25f).SetEase(Ease.Linear).SetLoops(20, LoopType.Incremental);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        Instantiate(torpedo, kepalaPoint.position, kepalaPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        Instantiate(torpedo, kepalaPoint.position, kepalaPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        Instantiate(torpedo, kepalaPoint.position, kepalaPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        Instantiate(torpedo, kepalaPoint.position, kepalaPoint.rotation);
        yield return new WaitForSeconds(1f);
        Instantiate(torpedo, tanganPoint.position, tanganPoint.rotation);
        Instantiate(torpedo, kakiPoint.position, kakiPoint.rotation);
        Instantiate(torpedo, kepalaPoint.position, kepalaPoint.rotation);
    }

    IEnumerator StartDestruction()
    {
        for(int i = 0; i < 10; i++)
        {
            float x = Random.Range(-4f, 4f);
            float y = Random.Range(-4f, 4f);

            Vector3 hitPosition = new Vector3(player.position.x + x, player.position.y + y);
            Instantiate(hitFx, hitPosition, Quaternion.identity);

            x = Random.Range(-4f, 4f);
            y = Random.Range(-4f, 4f);

            hitPosition = new Vector3(player.position.x + x, player.position.y + y);
            Instantiate(hitFx, hitPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);


            if (i == 5)
            {
                fadeout.SetActive(true);
                fadeout.GetComponent<Image>().DOFade(1, 2.5f).OnComplete(GameOver);
                fadeout.GetComponentInChildren<Text>().DOColor(Color.white, 2.5f);
            }
        }
        
    }

    void GameOver()
    {
        StartCoroutine(GameOverCo());
    }

    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(2.5f);
        fadeout.GetComponentInChildren<Text>().DOColor(Color.black, 2.5f);
        yield return new WaitForSeconds(2.5f);
        Application.LoadLevel("Credit");
    }
}
