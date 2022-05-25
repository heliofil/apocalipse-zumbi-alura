using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGeneratorController 
{
    void SetTimeToNew(int timeToNew);
    Vector3 PositionGenerator();
    void CreateInstance();

}
