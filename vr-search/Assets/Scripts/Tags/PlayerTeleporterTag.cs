using BlueTea.Core.Tags;
using UnityEngine;

public class PlayerTeleporterTag : ITag
{
    public bool Validate(TagComponent tagComponent)
    {
        if (tagComponent.GetComponentInChildren<PlayerTeleporter>())
                return true;

            return tagComponent.GetComponentInChildren<PlayerTeleporter>();
    }

    public string ValidationErrorMessage()
    {
        return $"{nameof(PlayerTeleporter)} is not present on this {nameof(GameObject)}";
    }
}
