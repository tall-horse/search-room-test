using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private ScoreContainerSO scoreSource;
    [SerializeField] private ItemType itemType;
    public int ItemScore { get; private set; } = 0;
    [HideInInspector] public bool isCollisionTriggered = false;
    public enum ItemType
    {
        CRYPTO,
        USEFULNONCRYPTO,
        NEUTRAL,
        NONCRYPTO
    }
    void Start()
    {
        SetItemScore(itemType);
    }

    public void TriggerCollision()
    {
        isCollisionTriggered = !isCollisionTriggered;
    }

    private void SetItemScore(ItemType selectedItemType)
    {
        switch (selectedItemType)
        {
            case ItemType.CRYPTO:
                ItemScore = scoreSource.CryptoItemScore;
                break;

            case ItemType.USEFULNONCRYPTO:
                ItemScore = scoreSource.UsefulNonCryptoScore;
                break;

            case ItemType.NEUTRAL:
                ItemScore = scoreSource.NeutralScore;
                break;

            case ItemType.NONCRYPTO:
                ItemScore = scoreSource.NonCryptoScore;
                break;
        }
    }
}
