using BlueTea.Core.Api;
using UnityEngine;
using VirtualStudio.Models;
namespace VR
{
    public class AutoLogin : MonoBehaviour
    {
        [SerializeField] private string levelId;
        [SerializeField] private string email;
        [SerializeField] private string password;
        private void Start()
        {
            VirtualStudioService.Instance.LoginDataRetrieved += OnLoginDataRetrieved;
            VirtualStudioService.Instance.Authenticate(email, password, false);
        }
        private void OnLoginDataRetrieved(bool success)
        {
            if (success)
            {
                LoadLevel(levelId);
                Debug.Log("Login succeeded");
            }
            else
            {
                Debug.LogError("Login failed.");
            }
        }
        private void LoadLevel(string levelId)
        {
            Level level = new Level();
            level.Id = levelId;
            Debug.Log("load level");
            LevelService.Instance.LoadLevel(level);
        }
    }
}