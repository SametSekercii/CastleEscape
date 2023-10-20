
using System.Collections.Generic;
using UnityEngine;

public interface IFieldOfView
{
    Perspective fieldOfView {  get; set; }
    List<Transform> GetVisibleTargets();
    


}
