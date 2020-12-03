using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_WallMat : MonoBehaviour
{
    public string _matString;
    [SerializeField]
    public int _noiseReductionInt;

    public enum _objMaterials {Wood=10,Plaster=20,Metal=35,Concrete=45} //Values indicate what will be divided by 100 to mulitply by volume of sound effect heard
    public _objMaterials _mat;

    private void Update()
    {
        _objMaterials _matCurr = _mat;
        _matString = _matCurr.ToString();
        _noiseReductionInt = (int)_matCurr;
    }
}
