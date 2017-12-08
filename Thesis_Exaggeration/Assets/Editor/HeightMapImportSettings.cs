using UnityEditor;

public class HeightMapImportSettings : AssetPostprocessor
{

    void OnPreprocessTexture()
    {
        if (assetPath.Contains("Assets/RealWater/Height Maps/"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Default;
            textureImporter.isReadable = true;
            textureImporter.npotScale = TextureImporterNPOTScale.None;
            textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
            textureImporter.maxTextureSize = 4096;
        }
    }
}