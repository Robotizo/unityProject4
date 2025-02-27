using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextsContainer;

    [Header("Tweening Parameters")]
    [SerializeField] private float moveAmount;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;

    private void Awake()
    {
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextsContainer.localPosition.y;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        coinTextsContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(SetCoinContainer(score));
    }

    private IEnumerator SetCoinContainer(int score)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = coinTextsContainer.localPosition;
        coinTextsContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}
