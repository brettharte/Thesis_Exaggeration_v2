using UnityEngine;
using UnityEditor;
using System.IO;

public class NormalMapGenerator : ScriptableWizard
{
    public int width = 512;
    public int height = 512;
    public string optionalFileName;
    public enum ImageType
    {
        NormalMap, HeightMap
    }
    public ImageType imageType;


    private void setPix(Texture2D img)
    {
        int length = width * height;
        Color32[] nMapPixels = new Color32[length];

        //Initialize the image
        for (int i = 0; i < length; i++)
        {
            nMapPixels[i] = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        }
        img.SetPixels32(nMapPixels);
    }

    [MenuItem("RealWater/Create Normal Map (Manual)")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Normal Map (Manual)", typeof(NormalMapGenerator));
    }

    void OnWizardUpdate()
    {
        int size = width * height;

        if (size >= 16777216)
        {
            errorString = "This will generate too large an image! Either reduce the scale or the quality setting.";
            isValid = false;
        }

        else if (width < 1 || height < 1)
        {
            errorString = "Width/Height cannot be less than 1.";
            isValid = false;
        }
        else
        {
            errorString = "";
            isValid = true;
        }
    }

    bool ConsistsOfWhiteSpace(string s)
    {
        foreach (char c in s)
        {
            if (c != ' ') return false;
        }
        return true;

    }

    void OnWizardCreate()
    {
        if (string.IsNullOrEmpty(optionalFileName) || ConsistsOfWhiteSpace(optionalFileName))
            optionalFileName = width + "x" + height;

        Texture2D img = new Texture2D(width, height, TextureFormat.ARGB32, true);
        setPix(img);

        if (imageType == ImageType.NormalMap)
        {
            //Check if directory is present
            if (!Directory.Exists("Assets/RealWater/Normal Maps/"))
            {
                //If not, create it
                Directory.CreateDirectory("Assets/RealWater/Normal Maps/");
            }

            System.IO.File.WriteAllBytes("Assets/RealWater/Normal Maps/" + optionalFileName + ".png", img.EncodeToPNG());
        }
        else
        {
            //Check if directory is present
            if (!Directory.Exists("Assets/RealWater/Height Maps/"))
            {
                //If not, create it
                Directory.CreateDirectory("Assets/RealWater/Height Maps/");
            }

            System.IO.File.WriteAllBytes("Assets/RealWater/Height Maps/" + optionalFileName + ".png", img.EncodeToPNG());
        }

        AssetDatabase.Refresh();
    }
}
