using UnityEngine;

public class CryptoPiece : MonoBehaviour, IPickupable
{
    [SerializeField] private int toScore;
    public int PointsToScore
    {
        get => toScore;
        set => toScore = value;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
