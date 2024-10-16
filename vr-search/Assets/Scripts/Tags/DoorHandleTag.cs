using BlueTea.Core.Tags;
using UnityEngine;

public class DoorHandleTag : ITag
{
    public bool Validate(TagComponent tagComponent)
    {
        if (tagComponent.CompareTag("Door Handle"))
                return true;

            return tagComponent.CompareTag("Door Handle");
    }

    public string ValidationErrorMessage()
    {
        return $"Door Handle tag is not assigned to this {nameof(GameObject)}";
    }
}
