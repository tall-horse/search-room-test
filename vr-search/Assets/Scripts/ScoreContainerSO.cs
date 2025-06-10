using UnityEngine;

[CreateAssetMenu(fileName = "ScoreContainerSO", menuName = "Scriptable Objects/ScoreContainerSO")]
public class ScoreContainerSO : ScriptableObject
{
    [field: SerializeField] public int CryptoItemScore { get; private set; } = 10;
    [field: SerializeField] public int UsefulNonCryptoScore { get; private set; } = 5;
    [field: SerializeField] public int NeutralScore { get; private set; } = 0;
    [field: SerializeField] public int NonCryptoScore { get; private set; } = -5;
}
