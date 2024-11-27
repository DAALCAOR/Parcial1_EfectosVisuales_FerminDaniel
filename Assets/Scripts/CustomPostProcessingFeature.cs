using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomPostProcessingFeature : ScriptableRendererFeature
{
    [System.Serializable]
    public class Settings
    {
        public Material postProcessMaterial; // Material para el efecto
    }

    public Settings settings = new Settings();

    private CustomPostProcessingPass customPass;

    public override void Create()
    {
        customPass = new CustomPostProcessingPass(settings.postProcessMaterial);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (settings.postProcessMaterial != null)
        {
            customPass.Setup(renderer.cameraColorTarget);
            renderer.EnqueuePass(customPass);
        }
    }

    class CustomPostProcessingPass : ScriptableRenderPass
    {
        private Material material;
        private RenderTargetIdentifier source;

        public CustomPostProcessingPass(Material material)
        {
            this.material = material;
            renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
        }

        public void Setup(RenderTargetIdentifier source)
        {
            this.source = source;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (material == null)
                return;

            CommandBuffer cmd = CommandBufferPool.Get("CustomPostProcessing");
            cmd.Blit(source, source, material);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}
