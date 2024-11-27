using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Video_Camera_Controller : MonoBehaviour
{
    public static Video_Camera_Controller Instance;

    public bool spacePressed;
    #region Singleton
    public void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("<color=blue>Color Adjustment</color>")]

    [SerializeField] private Material _colAdjPP;

    public Material ColAdjPP
    {
        get { return _colAdjPP; }
        set { _colAdjPP = value; }
    }

    [Header("<color=red>Vignette</color>")]

    [SerializeField] private Material _vignettePP;

    public Material VignettePP
    {
        get { return _vignettePP; }
        set { _vignettePP = value; }
    }

    public float _vignetteBlur;
    public float _vignetteScale;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Update()
    {
        SetVignetteBlur();
        SetVignetteScale();
    }

    public void PostProcessState(bool isActive)
    {
        _anim.SetBool("isActive", isActive);
        _anim.SetTrigger("onEnable");
    }

    public void SetVignetteScale()
    {
        _vignettePP.SetFloat("_VignetteScale", _vignetteScale);
    }

    public void SetVignetteBlur()
    {
        _vignettePP.SetFloat("_VignetteBlur", _vignetteBlur);
    }

    public void ToogleOn()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    spacePressed = !spacePressed;
        //}
    }
}
