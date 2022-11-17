using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface ISelectionResponse
{
    void OnDeselect(Transform selection);
    void OnSelect(Transform selection);
}
