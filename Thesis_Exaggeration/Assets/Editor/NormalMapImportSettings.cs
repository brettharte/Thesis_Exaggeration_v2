using UnityEditor;

class NormalMapImportSettings : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        if (assetPath.Contains("Assets/RealWater/Normal Maps/"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.NormalMap;
            textureImporter.isReadable = true;
            textureImporter.npotScale = TextureImporterNPOTScale.None;
            textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
            textureImporter.maxTextureSize = 4096;
        }
    }
}