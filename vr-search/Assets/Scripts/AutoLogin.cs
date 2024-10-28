using System.Collections.Generic;
using BlueTea.Core.Api;
using UnityEngine;

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
            //VirtualStudioService.Instance.Authenticate(email, password, false);
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
            Debug.Log("load level");
            VirtualStudioService.Instance.GetLevel(levelId, ProcessLevel_Handler);
        }

        private void ProcessLevel_Handler(VirtualStudio.Models.Level level)
        {
            Debug.Log("process level handler");
            VirtualStudioService.Instance.GetMedia(level, MediaDownloaded_Handler);
        }

        private void MediaDownloaded_Handler(List<VirtualStudio.Models.Media> list)
        {
            Debug.Log("start level");
            LevelService.Instance.StartLevel();
        }
    }
}
