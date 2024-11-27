using UnityEngine;

public class ShaderController : MonoBehaviour
{
    [Header("Material del Shader")]
    public Material materialShader; // El material que tiene el shader con el booleano
    public string booleanPropertyName = "_IsActive"; // Nombre de la propiedad booleana en el shader
    public KeyCode toggleKey = KeyCode.E; // Tecla para alternar el valor del booleano

    private bool isActive = false; // Estado del booleano en el shader

    void Update()
    {
        // Alternar el valor del booleano cuando se presiona la tecla
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleShaderBoolean();
        }
    }

    void ToggleShaderBoolean()
    {
        // Cambiar el estado
        isActive = !isActive;

        // Asignar el nuevo valor al material
        if (materialShader != null)
        {
            materialShader.SetInt(booleanPropertyName, isActive ? 1 : 0); // 1 = true, 0 = false
            Debug.Log($"El valor de _IsActive en el shader es: {isActive}");
        }
        else
        {
            Debug.LogError("No se ha asignado el material del shader.");
        }
    }
}
