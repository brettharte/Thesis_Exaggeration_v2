using UnityEngine;
using UnityEditor;
using System.IO;

public class NormalMapGeneratorAuto : ScriptableWizard
{
    public float xScale = 1;
    public float zScale = 1;
    public string optionalFileName;

    public enum Quality
    {
        medium,high,vHigh
    }
    public Quality quality = Quality.medium;
    [Tooltip("Image dimensions will be rounded to the nearest power of two. (May give better performance).")]
    public bool powerOfTwo = false;
    private int width;
    private int height;
    public enum ImageType
    {
        NormalMap, HeightMap
    }
    public ImageType imageType;
    public bool unlockSize = false;

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

    private int calcSize(float scale)
    {
        int size;

       if(quality == Quality.vHigh)
        {
            size =(int) (192 * scale);
        }
        else if(quality == Quality.high)
        {
            size = (int) (128 * scale);
        }
        else
        {
            size = (int) (96 * scale);
        }

        if (powerOfTwo)
        {
            if (!powerTwo(size))
            {
                size = nPOT(size);
            }
        }
        return size;
    }

    private int nPOT(int x)
    {
        int y = 2;

        while(y < x)
        {
            y *= 2;
        }

        return y;
    }

    private bool powerTwo(int x)
    {
        while (((x % 2) == 0) && x > 1)
            x /= 2;

        return (x == 1);
    }


    [MenuItem("RealWater/Create Normal Map (Auto)")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Create Normal Map (Auto)", typeof(NormalMapGeneratorAuto));
    }


    void OnWizardUpdate()
    {
        int w = calcSize(xScale);
        int h = calcSize(zScale);
        int limit;
        int size = w * h;

        if (unlockSize)
            limit = 16777216; //4096x4096
        else
            limit = 4194303; //2048x2048

        if (size >= limit)
        {
            errorString = "This will generate too large an image! Either reduce the scale or the quality setting.";
            isValid = false;
        }
        else if(xScale < 1 || zScale < 1)
        {
            errorString = "Scale cannot be less than 1.";
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
        width = calcSize(xScale);
        height = calcSize(zScale);

        Texture2D img = new Texture2D(width, height, TextureFormat.ARGB32, true);
        setPix(img);

        if (string.IsNullOrEmpty(optionalFileName) || ConsistsOfWhiteSpace(optionalFileName))
            optionalFileName = width + "x" + height;

        if (imageType == ImageType.NormalMap)
        {
            //Check if directory is present
            if (!Directory.Exists("Assets/RealWater/Normal Maps/"))
            {
                //If not, create it
                Directory.CreateDirectory("Assets/RealWater/Normal Maps/");
            }

            if (optionalFileName == null)
                optionalFileName = width + "x" + height + ".png";

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
