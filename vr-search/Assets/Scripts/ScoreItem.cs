using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    [SerializeField] private ScoreContainerSO scoreSource;
    [SerializeField] private ItemType itemType;
    public int ItemScore {get; private set;} = 0;
    public bool isCollisionTriggered = false;
    public enum ItemType
    {
        CRYPTO,
        USEFULNONCRYPTO,
        NONCRYPTO
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

            case ItemType.NONCRYPTO:
            ItemScore = scoreSource.NonCryptoScore;
            break;
        }
    }
}
